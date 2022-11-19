using UnityEngine;

[DisallowMultipleComponent, RequireComponent(typeof(ImpactComponent_Addon_UI))]
public class ImpactComponent_Input_Custom : JTools.ImpactComponent_Input
{
    //The default input component, built around Unity's default input system.
    [Header("Default - General Controls")]
    public string lookAxisX = "Mouse X";
    public string lookAxisY = "Mouse Y";
    [Space]
    public string movementStrafe = "Horizontal";
    public string movementWalk = "Vertical";
    [Space]
    public KeyCode keyCrouch = KeyCode.LeftControl;
    public KeyCode keyJump = KeyCode.Space;
    public KeyCode keySprint = KeyCode.LeftShift;

    public KeyCode keyMenu = KeyCode.Escape;
    [Space]
    public JTools.ImpactInput_MouseSetting buttonPrimary = JTools.ImpactInput_MouseSetting.leftMouse;
    public JTools.ImpactInput_MouseSetting buttonSecondary = JTools.ImpactInput_MouseSetting.rightMouse;
    [Space]
    public KeyCode keyInteract = KeyCode.E;

    private ImpactComponent_Addon_UI _uiAddon;

    public override void ComponentInitialize(JTools.ImpactController player)
    {
        base.ComponentInitialize(player);

        _uiAddon = GetComponent<ImpactComponent_Addon_UI>();
    }

    public override void Controls()
    {
        inputData.mouseInput = new Vector2(Input.GetAxis(lookAxisX), Input.GetAxis(lookAxisY));

        inputData.pressedPrimary = Input.GetMouseButtonDown((int)buttonPrimary);
        inputData.holdingPrimary = Input.GetMouseButton((int)buttonPrimary);
        inputData.releasedPrimary = Input.GetMouseButtonUp((int)buttonPrimary);

        inputData.pressedSecondary = Input.GetMouseButtonDown((int)buttonSecondary);
        inputData.holdingSecondary = Input.GetMouseButton((int)buttonSecondary);
        inputData.releasedSecondary = Input.GetMouseButtonUp((int)buttonSecondary);

        inputData.motionInput = new Vector3(Input.GetAxisRaw(movementStrafe), 0f, Input.GetAxisRaw(movementWalk)).normalized;

        inputData.pressedCrouch = Input.GetKeyDown(keyCrouch);
        inputData.holdingCrouch = Input.GetKey(keyCrouch);
        inputData.releasedCrouch = Input.GetKeyUp(keyCrouch);

        inputData.pressedJump = Input.GetKeyDown(keyJump);
        inputData.holdingJump = Input.GetKey(keyJump);
        inputData.releasedJump = Input.GetKeyUp(keyJump);

        inputData.pressedSprint = Input.GetKeyDown(keySprint);
        inputData.holdingSprint = Input.GetKey(keySprint);
        inputData.releasedSprint = Input.GetKeyUp(keySprint);

        inputData.pressedMenu = Input.GetKeyDown(keyMenu);
        inputData.holdingMenu = Input.GetKey(keyMenu);
        inputData.releasedMenu = Input.GetKeyUp(keyMenu);

        inputData.pressedInteract = Input.GetKeyDown(keyInteract);
        inputData.holdingInteract = Input.GetKey(keyInteract);
        inputData.releasedInteract = Input.GetKeyUp(keyInteract);
    }

    public override void ControlsLocked()
    {
        base.ControlsLocked();

        if (_uiAddon.MenusOpen)
        {
            Debug.Log("UI OPEN");
            inputData.pressedInteract = false;
        }
        else
        {
            Debug.Log("UI CLOSED");
            inputData.pressedInteract = Input.GetKeyDown(keyInteract);
        }

        inputData.pressedMenu = Input.GetKeyDown(keyMenu);
    }
}