using UnityEngine;

namespace InputLogic
{

    public class GyroscopeInput : BaseInput
    {

        #region Constructors

        public GyroscopeInput()
        {

            Input.gyro.enabled = true;

        }

        #endregion

        #region Destructors

        ~GyroscopeInput()
        {

            Dispose();

        }

        #endregion

        #region Base Methods

        public override void OnUpdate(float deltaTime)
        {

            var quaternion      = Input.gyro.attitude;

            var acceleration    = new Vector3(quaternion.x, quaternion.y);
            var accelerationX   = Mathf.Abs(acceleration.x);

            if (accelerationX >= InputDeadZone.Gyroscope)
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