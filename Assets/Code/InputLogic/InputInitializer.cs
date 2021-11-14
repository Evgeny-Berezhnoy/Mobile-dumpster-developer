using System;
using UnityEngine;
using MVC;
using UserInterface;

namespace InputLogic
{
    public class InputInitializer
    {

        #region Fields

        private BaseInput _inputController;

        #endregion

        #region Properties

        public BaseInput InputController => _inputController;

        #endregion

        #region Constructors

        public InputInitializer(ControllersList controllersList, EInputMode mode, IGameplayUIView gameplayUIView)
        {

            _inputController = GetInput(mode, gameplayUIView);

            controllersList.AddController(_inputController);

        }

        #endregion

        #region Methods

        private BaseInput GetInput(EInputMode mode, IGameplayUIView gameplayUIView)
        {

            if (mode == EInputMode.Accelerometer)
            {

                return new AccelerometerInput();

            }
            else if (mode == EInputMode.Gyroscope)
            {

                return new GyroscopeInput();

            }
            else if (mode == EInputMode.Joystick
                        && (gameplayUIView is IJoystickGameplayUIView joystickGameplayUIView))
            {

                return new JoystickInput(joystickGameplayUIView.JoystickView);

            }
            else
            {

                throw new Exception("Couldn't determine input type.");

            };

        }

        #endregion

    }

}