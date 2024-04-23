using UnityEngine;
using UnityEngine.Events;

namespace JTools
{
    // TODO: Make controller using new inputsystem
    public abstract class ImpactComponent_Input : ImpactComponent
    {
        //This is an abstract class you can use to implement your own input systems for Impact.
        //It explicitly exists because of how many different input solutions exist for Unity, so I wanted to create a more universal approach for Impact so you can have whatever input manager you need to operate the controller.

        //OUTPUTS
        public InputData inputData = new(Vector3.zero); //A generalized struct containing input data for Impact.

        [HideInInspector]
        public UnityEvent onLock; //Runs when ChangeLockState is called and set to true.
        [HideInInspector]
        public UnityEvent onUnlock; //Runs when ChangeLockState is called and set to false.

        //INPUTS
        public bool LockInput { get => _lockInput; }

        private bool _lockInput = false; //Allows you to lock input. You can choose whether or not you want to opt into this system in your own components.

        public void Reset()
        {
            var controller = GetComponent<ImpactController>();
            if (controller)
            {
                if (controller.inputComponent == null)
                {
                    controller.inputComponent = this;
                }
                else if (controller.inputComponent != this)
                {
                    Debug.LogWarning("Multiple inputComponent registered. May cause problems.", this);
                }
            }
        }

        public virtual void ChangeLockState(bool lockState)
        {
            if (lockState != LockInput)
            {
                if (lockState)
                    onLock.Invoke();
                else
                    onUnlock.Invoke();
            }

            _lockInput = lockState;
        }

        public override void ComponentUpdate(ImpactController player)
        {
            base.ComponentUpdate(player);

            if (!LockInput)
                Controls();
            else
                ControlsLocked();
        }

        //This is used to read the inputs for all controls related to movement.
        public virtual void Controls()
        {
            //You can write whatever you need in here, if you're implementing a new input layout.
        }

        //This is commonly used to determine what the locking values should be when the player's movement is locked.
        //By default this'll disable everything. Feel free to override if you need non-zero default values for stuff.
        public virtual void ControlsLocked()
        {
            inputData.motionInput = Vector3.zero;
            inputData.mouseInput = Vector2.zero;

            inputData.pressedMenu = false;
            if (inputData.holdingMenu)
                inputData.releasedMenu = true;
            else
                inputData.releasedMenu = false;
            inputData.holdingMenu = false;
        }
    }

    public struct InputData
    {
        public Vector2 cursorPosition;

        public Vector3 motionInput;
        public Vector2 mouseInput;

        public bool pressedMenu;
        public bool holdingMenu;
        public bool releasedMenu;

        public bool pressedInteract;
        public bool holdingInteract;
        public bool releasedInteract;

        public InputData(Vector3 initialMotion)
        {
            cursorPosition = Vector2.zero;

            motionInput = initialMotion;
            mouseInput = Vector2.zero;

            pressedMenu = false;
            holdingMenu = false;
            releasedMenu = false;

            pressedInteract = false;
            holdingInteract = false;
            releasedInteract = false;
        }
    }
}