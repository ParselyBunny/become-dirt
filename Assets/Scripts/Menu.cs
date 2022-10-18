using UnityEngine;

public class Menu
{
    public GameObject ParentObject { get; private set; }
    public bool StartEnabled { get; private set; }
    public bool AlwaysEnabled { get; private set; }

    public Menu(GameObject obj, bool se, bool ae)
    {
        this.ParentObject = obj;
        this.StartEnabled = se;
        this.AlwaysEnabled = ae;
    }
}

public class MenuComponent : MonoBehaviour
{
    [SerializeField]
    private bool StartEnabled;
    [SerializeField]
    private bool AlwaysEnabled;

    private Menu asMenu;

    private void Awake()
    {
        this.asMenu = new Menu(this.gameObject, StartEnabled, AlwaysEnabled);
        UIMenus.AddMenu(this.asMenu);
    }

    private void OnDestroy()
    {
        UIMenus.RemoveMenu(this.asMenu);
    }
}
