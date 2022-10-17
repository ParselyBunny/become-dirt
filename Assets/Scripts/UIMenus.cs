using System.Collections.Generic;
using UnityEngine;

public static class UIMenus
{
    public static Dictionary<string, Menu> Menus { get { return _menus; } }

    [SerializeField]
    private static Dictionary<string, Menu> _menus;

    public static void RefreshViews()
    {
        foreach (KeyValuePair<string, Menu> entry in _menus)
        {
            entry.Value.ParentObject.SetActive(
                entry.Value.StartEnabled || entry.Value.AlwaysEnabled
            );
        }
    }

    public static void AddMenu(Menu menu)
    {
        if (_menus.ContainsKey(menu.ParentObject.name))
        {
            Debug.LogWarningFormat("Trying to AddMenu that already exists with name %s", menu.ParentObject.name);
            return;
        }
        menu.ParentObject.SetActive(menu.StartEnabled || menu.AlwaysEnabled);
        _menus.Add(menu.ParentObject.name, menu);
    }

    public static void RemoveMenu(Menu menu)
    {
        if (_menus.ContainsKey(menu.ParentObject.name))
        {
            _menus.Remove(menu.ParentObject.name);
            return;
        }
        Debug.LogFormat("Trying to RemoveMenu that already exists with name %s", menu.ParentObject.name);
    }

    public static void SetActiveMenu(string menuName)
    {
        foreach (KeyValuePair<string, Menu> entry in _menus)
        {
            entry.Value.ParentObject.SetActive(
                entry.Value.ParentObject.name == menuName || entry.Value.AlwaysEnabled
            );
        }
    }
}
