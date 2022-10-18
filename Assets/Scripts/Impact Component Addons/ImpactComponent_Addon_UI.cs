using UnityEngine;

namespace JTools
{
    public class ImpactComponent_Addon_UI : ImpactComponent_Addon
    {
        [SerializeField]
        private string _pauseMenuName;

        public override void ComponentUpdate(ImpactController player)
        {
            base.ComponentUpdate(player);

            if (owner.inputComponent.inputData.pressedMenu)
            {
                UIMenus.SetActiveMenu(this._pauseMenuName);
            }
        }
    }
}