using UnityEngine;

namespace UserInterface
{

    public class GameplayJoystickUIView : GameplayUIView, IJoystickGameplayUIView
    {

        #region Fields

        [SerializeField] private Joystick _joystickView;

        #endregion

        #region Interface Properties

        public Joystick JoystickView => _joystickView;

        #endregion

    }

}