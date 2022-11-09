using UnityEngine;

namespace JTools
{
    public class ImpactComponent_Addon_UI : ImpactComponent_Addon
    {
        [SerializeField]
        private string _pauseMenuName = "Pause Menu";

        private bool menusOpen = false;

        public override void ComponentUpdate(ImpactController player)
        {
            base.ComponentUpdate(player);

            if (owner.inputComponent.inputData.pressedMenu)
            {
                Debug.LogFormat("Toggling Pause Menu - now enabled: `{0}`", !menusOpen);
                if (menusOpen)
                {
                    UIMenus.SetActiveMenu("");
                    menusOpen = false;
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
                    menusOpen = true;
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
}