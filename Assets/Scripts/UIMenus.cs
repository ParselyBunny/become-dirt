using System.Collections.Generic;
using UnityEngine;

public static class UIMenus
{
    public static Dictionary<string, Menu> Menus { get { return _menus; } }

    [SerializeField]
    private static Dictionary<string, Menu> _menus = new Dictionary<string, Menu>();

    public static void RefreshViews()
    {
        foreach (KeyValuePair<string, Menu> entry in _menus)
        {
            entry.Value.MenuRoot.SetActive(
                entry.Value.StartEnabled || entry.Value.AlwaysEnabled
            );
        }
    }

    public static void AddMenu(Menu menu)
    {
        if (_menus.ContainsKey(menu.MenuRoot.name))
        {
            Debug.LogWarningFormat("Trying to AddMenu that already exists with name %s", menu.MenuRoot.name);
            return;
        }
        menu.MenuRoot.SetActive(menu.StartEnabled || menu.AlwaysEnabled);
        _menus.Add(menu.MenuRoot.name, menu);
    }

    public static void RemoveMenu(Menu menu)
    {
        if (_menus.ContainsKey(menu.MenuRoot.name))
        {
            _menus.Remove(menu.MenuRoot.name);
            return;
        }
        Debug.LogFormat("Trying to RemoveMenu that already exists with name %s", menu.MenuRoot.name);
    }

    // TODO: There's a better way to do this without relying on an 'accurate string'
    public static void SetActiveMenu(string menuName)
    {
        Debug.LogFormat("Setting Active UI Menu to `{0}`", menuName);
        foreach (KeyValuePair<string, Menu> entry in _menus)
        {
            entry.Value.MenuRoot.SetActive(
                entry.Value.MenuRoot.name == menuName || entry.Value.AlwaysEnabled
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
}
