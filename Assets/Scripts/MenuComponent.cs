using UnityEngine;

public class Menu
{
    public GameObject MenuRoot { get; private set; }
    public bool StartEnabled { get; private set; }
    public bool AlwaysEnabled { get; private set; }
    public bool AlwaysEnabledOverride { get; private set; }

    public Menu(GameObject obj, bool se, bool ae)
    {
        this.MenuRoot = obj;
        this.StartEnabled = se;
        this.AlwaysEnabled = ae;
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
        this.asMenu = new Menu(this.gameObject, StartEnabled, AlwaysEnabled);

        _wasAdded = UIMenus.AddMenu(this.asMenu);
    }

    private void OnDestroy()
    {
        if (_wasAdded)
        {
            UIMenus.RemoveMenu(this.asMenu);
        }
    }

    public void SetActiveMenu(string menuName)
    {
        UIMenus.SetActiveMenu(menuName);
    }
}
