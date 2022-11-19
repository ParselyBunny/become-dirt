using UnityEngine;

[DisallowMultipleComponent]
public class ImpactComponent_Addon_UI : JTools.ImpactComponent_Addon
{
    [SerializeField]
    private string _pauseMenuName = "Pause Menu";

    public bool MenusOpen;

    public override void ComponentUpdate(JTools.ImpactController player)
    {
        base.ComponentUpdate(player);

        if (owner.inputComponent.inputData.pressedMenu)
        {
            Debug.LogFormat("Toggling Pause Menu - now enabled: `{0}`", !MenusOpen);
            if (MenusOpen)
            {
                UIMenus.SetActiveMenu("");
                MenusOpen = false;
                if (!InkManager.IsPlaying)
                {
                    owner.inputComponent.ChangeLockState(false);
                }
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                UIMenus.SetActiveMenu(this._pauseMenuName);
                MenusOpen = true;
                if (!InkManager.IsPlaying)
                {
                    owner.inputComponent.ChangeLockState(true);
                }
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
