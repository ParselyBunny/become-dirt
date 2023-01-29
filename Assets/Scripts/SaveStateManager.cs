using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class SaveStateManager
{
    public const string VERSION = "0.1";
    private static string _savePath = System.IO.Path.Combine(Application.dataPath, "Saves", (VERSION + ".json"));

    private static Dictionary<string, GameObject> _markedObjects = new Dictionary<string, GameObject>();
    private static StateSerializer[] _serializersInScene;
    private static Dictionary<string, SaveObject.ObjectState> _saveFile = new Dictionary<string, SaveObject.ObjectState>();

    static SaveStateManager()
    {
        LoadSaveFile();
    }

    public static void LoadSaveFile()
    {
        if (!System.IO.File.Exists(_savePath))
        {
            Debug.LogWarningFormat("Save file does not exist with path `{0}`", _savePath);
            return;
        }

        var rawSave = System.IO.File.ReadAllText(_savePath);
        var saveDataList = JsonUtility.FromJson<List<SaveObject>>(rawSave);

        _saveFile = saveDataList.ToDictionary(obj => obj.UUID, obj => obj.State);
    }

    public static void LoadObjectByUUID(string uuid)
    {
        if (_serializersInScene == null)
        {
            _serializersInScene = GameObject.FindObjectsOfType<StateSerializer>();
        }

        for (int i = 0; i < _serializersInScene.Length; i++)
        {
            if (_serializersInScene[i].UUID == uuid)
            {
                if (_markedObjects.ContainsKey(_serializersInScene[i].UUID))
                {
                    var go = _markedObjects[_serializersInScene[i].UUID];
                    if (go == null)
                    {
                        Debug.LogErrorFormat("Reference to scene serializer `{0}` became null.", uuid);
                        continue;
                    }

                    switch (_saveFile[uuid])
                    {
                        case SaveObject.ObjectState.Destroyed:
                            Object.Destroy(_serializersInScene[i].gameObject);
                            break;
                        case SaveObject.ObjectState.Enabled:
                            _serializersInScene[i].gameObject.SetActive(true);
                            break;
                        case SaveObject.ObjectState.Disabled:
                            _serializersInScene[i].gameObject.SetActive(false);
                            break;
                        default:
                            Debug.LogErrorFormat("Invalid object state retrieved for `{0}`.", uuid);
                            break;
                    }
                }
                else
                {
                    Debug.LogErrorFormat("Something went bad trying to locate `{0}` in the scene!", uuid);
                }
            }
        }
    }

    public static void MarkObjectForSaving(StateSerializer obj)
    {
        if (obj == null)
        {
            Debug.LogWarning("Object marked for saving is null.");
            return;
        }

        if (!_markedObjects.ContainsKey(obj.UUID))
        {
            _markedObjects.Add(obj.UUID, obj.gameObject);
        }
    }

    public static void SaveGame()
    {
        List<SaveObject> data = new List<SaveObject>(_markedObjects.Count);

        foreach (KeyValuePair<string, GameObject> kv in _markedObjects)
        {
            data.Add(new SaveObject(kv.Key, kv.Value));
        }

        string saveData = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(_savePath, saveData);
    }
}

[System.Serializable]
public struct SaveObject
{
    public enum ObjectState
    {
        Destroyed,
        Disabled,
        Enabled
    }

    public string UUID { get; private set; }
    public ObjectState State { get; private set; }

    public SaveObject(string uuid, GameObject go)
    {
        this.UUID = uuid;

        if (go == null)
        {
            this.State = ObjectState.Destroyed;
        }
        else if (go.activeSelf)
        {
            this.State = ObjectState.Enabled;
        }
        else
        {
            this.State = ObjectState.Disabled;
        }
    }
}