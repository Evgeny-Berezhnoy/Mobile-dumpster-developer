using UnityEngine;

namespace InputLogic
{

    public class JoystickInput : BaseInput
    {

        #region Fields

        private Joystick _joystick;

        #endregion

        #region Constructors

        public JoystickInput(Joystick joystick)
        {

            _joystick = joystick;

        }

        #endregion

        #region Destructors

        ~JoystickInput()
        {

            Dispose();

        }

        #endregion

        #region Base Methods

        public override void OnUpdate(float deltaTime)
        {

            var acceleration = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
            var accelerationX = Mathf.Abs(acceleration.x);

            if (accelerationX > InputDeadZone.Joystick)
            {

                OnAxisShift(acceleration, deltaTime);

            };

        }

        public override void Dispose()
        {

            base.Dispose();

        }

        #endregion

    }

}