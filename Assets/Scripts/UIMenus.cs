using System.Collections.Generic;
using UnityEngine;

public static class UIMenus
{
    public static Dictionary<string, Menu> Menus { get { return _menus; } }

    [SerializeField]
    private static Dictionary<string, Menu> _menus = new();

    public static void RefreshOverrides()
    {
        foreach (KeyValuePair<string, Menu> entry in _menus)
        {
            if (entry.Value.AlwaysEnabledOverride != entry.Value.AlwaysEnabled)
            {
                entry.Value.SetAlwaysEnabledOverride(entry.Value.AlwaysEnabled);
                entry.Value.MenuRoot.SetActive(
                    entry.Value.StartEnabled || entry.Value.AlwaysEnabled
                );
            }
        }
    }

    public static bool AddMenu(Menu menu)
    {
        if (_menus.ContainsKey(menu.MenuRoot.name))
        {
            Debug.LogWarningFormat("Trying to AddMenu that already exists with name {0}", menu.MenuRoot.name);
            return false;
        }

        menu.MenuRoot.SetActive(menu.StartEnabled || menu.AlwaysEnabledOverride || menu.AlwaysEnabled);
        _menus.Add(menu.MenuRoot.name, menu);
        return true;
    }

    public static void RemoveMenu(Menu menu)
    {
        if (_menus.ContainsKey(menu.MenuRoot.name))
        {
            _menus.Remove(menu.MenuRoot.name);
            return;
        }

        Debug.LogFormat("Trying to RemoveMenu that already does not exist - name: {0}", menu.MenuRoot.name);
    }

    // TODO: There's a better way to do this without relying on an 'accurate string'
    public static void SetActiveMenu(string menuName)
    {
        Debug.LogFormat("Setting Active UI Menu to {0}", menuName);
        foreach (KeyValuePair<string, Menu> entry in _menus)
        {
            entry.Value.MenuRoot.SetActive(
                entry.Value.MenuRoot.name == menuName || entry.Value.AlwaysEnabledOverride || entry.Value.AlwaysEnabled
            );
        }
    }

    public static void HideMenu(string menuName)
    {
        Debug.LogFormat("Setting Active UI Menu to `{0}`", menuName);
        foreach (KeyValuePair<string, Menu> entry in _menus)
        {
            if (entry.Value.MenuRoot.name == menuName)
            {
                entry.Value.MenuRoot.SetActive(false);
            }
        }
    }

    public static GameObject GetMenuGameObject(string menuName)
    {
        foreach (KeyValuePair<string, Menu> entry in _menus)
        {
            if (entry.Value.MenuRoot.name == menuName)
            {
                return entry.Value.MenuRoot;
            }
        }

        Debug.LogWarningFormat("Failed to GetMenuGameObject with name: {0}", menuName);
        return null;
    }

    public static Menu GetMenu(string menuName)
    {
        foreach (KeyValuePair<string, Menu> entry in _menus)
        {
            if (entry.Value.MenuRoot.name == menuName)
            {
                return entry.Value;
            }
        }

        Debug.LogWarningFormat("Failed to GetMenu with name: {0}", menuName);
        return null;
    }
}
