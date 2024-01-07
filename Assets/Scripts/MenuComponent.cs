using UnityEngine;

public class Menu
{
    public GameObject MenuRoot { get; private set; }
    public bool StartEnabled { get; private set; }
    public bool AlwaysEnabled { get; private set; }
    public bool AlwaysEnabledOverride { get; private set; }

    public Menu(GameObject obj, bool se, bool ae)
    {
        MenuRoot = obj;
        StartEnabled = se;
        AlwaysEnabled = ae;
    }

    public void SetAlwaysEnabledOverride(bool alwaysEnabled)
    {
        AlwaysEnabledOverride = alwaysEnabled;
    }
}

public class MenuComponent : MonoBehaviour
{
    [SerializeField]
    private bool StartEnabled;
    [SerializeField]
    private bool AlwaysEnabled;

    private Menu asMenu;
    private bool _wasAdded;

    private void Start()
    {
        asMenu = new Menu(gameObject, StartEnabled, AlwaysEnabled);

        _wasAdded = UIMenus.AddMenu(asMenu);
    }

    private void OnDestroy()
    {
        if (_wasAdded)
        {
            UIMenus.RemoveMenu(asMenu);
        }
    }

    public void SetActiveMenu(string menuName)
    {
        UIMenus.SetActiveMenu(menuName);
    }
}
