using UnityEngine;

namespace InputLogic
{

    public class AccelerometerInput : BaseInput
    {

        #region Destructors

        ~AccelerometerInput()
        {

            Dispose();

        }

        #endregion

        #region Base Methods

        public override void OnUpdate(float deltaTime)
        {

            var acceleration    = new Vector3(Input.acceleration.x, Input.acceleration.y);
            var accelerationX   = Mathf.Abs(acceleration.x);

            if (accelerationX > InputDeadZone.Accelerometer)
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