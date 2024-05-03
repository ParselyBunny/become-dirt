using JTools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput)), DisallowMultipleComponent]
public class ImpactComponent_Input_Custom : JTools.ImpactComponent_Input
{
    public static ImpactComponent_Input_Custom PlayerInput;

    private PlayerInput _playerInput;
    private InputAction _mousePosition;
    private InputAction _lookAction;
    private InputAction _moveAction;
    private InputAction _menuAction;
    private InputAction _interactAction;

    public override void ComponentInitialize(ImpactController player)
    {
        base.ComponentInitialize(player);
        if (PlayerInput == null)
        {
            PlayerInput = this;
        }
        else
        {
            Debug.LogError("Multiple ImpactComponent_Input_Custom singleton!", this);
        }

        _playerInput = GetComponent<PlayerInput>();
        _mousePosition = _playerInput.actions["MousePosition"];
        _lookAction = _playerInput.actions["Look"];
        _moveAction = _playerInput.actions["Move"];
        _menuAction = _playerInput.actions["Menu"];
        _interactAction = _playerInput.actions["Interact"];
    }

    public override void Controls()
    {
        inputData.cursorPosition = _mousePosition.ReadValue<Vector2>();
        // print(inputData.cursorPosition);

        inputData.mouseInput = _lookAction.ReadValue<Vector2>();

        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        inputData.motionInput = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

        inputData.pressedMenu = _menuAction.WasPressedThisFrame();
        inputData.holdingMenu = _menuAction.IsPressed();
        inputData.releasedMenu = _menuAction.WasReleasedThisFrame();

        inputData.pressedInteract = _interactAction.WasPressedThisFrame();
        inputData.holdingInteract = _interactAction.IsPressed();
        inputData.releasedInteract = _interactAction.WasReleasedThisFrame();

        // Debug.Log(inputData.motionInput);
        // foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        // {
        //     if (Input.GetKey(kcode))
        //     {
        //         Debug.Log("KeyCode down: " + kcode);
        //     }
        // }
    }

    public override void ControlsLocked()
    {
        inputData.motionInput = Vector3.zero;
        inputData.mouseInput = Vector2.zero;

        inputData.pressedMenu = _menuAction.WasPressedThisFrame();
        inputData.holdingMenu = _menuAction.IsPressed();
        inputData.releasedMenu = _menuAction.WasReleasedThisFrame();

        inputData.pressedInteract = _interactAction.WasPressedThisFrame();
        inputData.holdingInteract = _interactAction.IsPressed();
        inputData.releasedInteract = _interactAction.WasReleasedThisFrame();
    }
}