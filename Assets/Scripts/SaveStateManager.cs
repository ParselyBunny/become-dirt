using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public static class SaveStateManager
{
    public const string VERSION = "0.2";
    private static string _saveDirectoryPath = Path.Combine(Application.dataPath, "Saves");
#if UNITY_EDITOR
    private static string _saveFileName = VERSION + "-editor.json";
#else
    private static string _saveFileName = VERSION + ".json";
#endif
    private static string SaveFileFullPath { get { return Path.Combine(_saveDirectoryPath, _saveFileName); } }

    private static Dictionary<string, GameObject> _markedObjects = new();
    private static Dictionary<string, SaveObject.ObjectState> _loadedSave = new();

    public static void MarkObjectForSaving(StateSerializer obj)
    {
        if (obj == null)
        {
            Debug.LogWarning("Object marked for saving is null.");
            return;
        }

        if (_markedObjects.ContainsKey(obj.UUID))
        {
            Debug.LogFormat("Object with UUID `{0}` already marked for saving.", obj.UUID);
            return;
        }

        if (obj.gameObject == null)
        {
            Debug.LogFormat("Object with UUID `{0}` has nil GameObject, will not mark.", obj.UUID);
            return;
        }

        if (obj.SkipSave)
        {
            Debug.LogWarningFormat("Object with UUID `{0}` designated to-be-skipped, will not mark.", obj.UUID);
            return;
        }

        // Debug.Log("Marking object for saving: " + obj.gameObject.name, obj.gameObject);
        _markedObjects.Add(obj.UUID, obj.gameObject);
        // Debug.Log($"Marked Contents:\n{string.Join("\n", _markedObjects)}");
    }

    public static void SaveGame()
    {
        // Debug.Log("Saving Game.");
        List<SaveObject> data = new(_markedObjects.Count);

        foreach (KeyValuePair<string, GameObject> kv in _markedObjects)
        {
            // Debug.Log("Marking object for saving: " + kv.Key, kv.Value);
            // var newObj = new SaveObject(kv.Key, kv.Value);
            // Debug.LogFormat("Marking object for saving: {0} {1}", newObj.UUID, newObj.State.ToString());
            data.Add(new SaveObject(kv.Key, kv.Value));
        }

        SaveFile saveData = new() { Objects = data.ToArray() };
        // Debug.Log($"List Contents:\n{string.Join("\n", data)}");
        // Debug.LogFormat("Save data in list: {0}", data.ToString());
        string saveDataJSON = JsonUtility.ToJson(saveData, true);
        // Debug.LogFormat("Save data written: {0}", saveDataJSON);
        File.WriteAllText(SaveFileFullPath, saveDataJSON);
        // Debug.Log("Game Saved.");
    }

    public static bool TryLoadSaveFile()
    {
        if (!Directory.Exists(_saveDirectoryPath))
        {
            Directory.CreateDirectory(_saveDirectoryPath);
            Debug.LogWarning("Save directory did not exist, creating now.");
        }
        if (!File.Exists(SaveFileFullPath))
        {
            Debug.LogWarningFormat("Save file does not exist, creating now. Path @ `{0}`", _saveDirectoryPath);
            File.Create(SaveFileFullPath);
            return false;
        }

        var rawLoadedData = File.ReadAllText(SaveFileFullPath);
        // Debug.LogFormat("Save File data: {0}", rawLoadedData);
        var loadedFile = JsonUtility.FromJson<SaveFile>(rawLoadedData);


        if (loadedFile == null)
        {
            Debug.LogWarning("Loaded Save File had no retrievable data.");
            _loadedSave = new Dictionary<string, SaveObject.ObjectState>();
            return false;
        }

        _loadedSave = loadedFile.Objects.ToDictionary(obj => obj.UUID, obj => obj.State);
        return true;
    }

    public static void ApplyLoadedFileToScene()
    {
        var _serializersInScene = Resources.FindObjectsOfTypeAll(typeof(StateSerializer)) as StateSerializer[];
        Debug.LogWarningFormat("IN SCENE = {0}", _serializersInScene.Length);
        StateSerializer currentSerializer;

        for (int i = 0; i < _serializersInScene.Length; i++)
        {
            currentSerializer = _serializersInScene[i];
            if (currentSerializer.SkipSave)
            {
                Debug.LogWarningFormat("Skipping manually-unsaved object for processing with UUID `{0}`", currentSerializer);
                continue;
            }

            if (_markedObjects.ContainsKey(currentSerializer.UUID))
            {
                var go = _markedObjects[currentSerializer.UUID];
                if (go == null)
                {
                    Debug.LogErrorFormat("Reference to scene serializer `{0}` became null.", currentSerializer.UUID);
                    continue;
                }

                switch (_loadedSave[currentSerializer.UUID])
                {
                    case SaveObject.ObjectState.Destroyed:
                        Object.Destroy(currentSerializer.gameObject);
                        break;
                    case SaveObject.ObjectState.Enabled:
                        currentSerializer.gameObject.SetActive(true);
                        break;
                    case SaveObject.ObjectState.Disabled:
                        currentSerializer.gameObject.SetActive(false);
                        break;
                    default:
                        Debug.LogErrorFormat("Invalid object state retrieved for `{0}`.", currentSerializer.UUID);
                        break;
                }
            }
            else
            {
                Debug.LogErrorFormat("Found unmarked save object `{0}` in the scene!", currentSerializer.UUID);
            }
        }
    }

    public static void ResetCache()
    {
        _markedObjects.Clear();
    }
}

[System.Serializable]
public class SaveFile
{
    public SaveObject[] Objects = new SaveObject[] { };
}

[System.Serializable]
public class SaveObject
{
    [System.Serializable]
    public enum ObjectState
    {
        Destroyed,
        Disabled,
        Enabled
    }

    public string UUID;
    public ObjectState State;

    public SaveObject(string uuid, GameObject go)
    {
        UUID = uuid;

        if (go == null)
        {
            State = ObjectState.Destroyed;
        }
        else if (go.activeSelf)
        {
            State = ObjectState.Enabled;
        }
        else
        {
            State = ObjectState.Disabled;
        }
    }
}
