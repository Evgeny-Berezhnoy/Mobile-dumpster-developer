using UnityEngine;

namespace Cars
{

    [CreateAssetMenu(menuName = "Configurations/Car", fileName = "Car configuration", order = 0)]
    public class CarConfiguration : ScriptableObject
    {

        #region Fields

        [SerializeField] private string _view;
        [SerializeField] private float _speed;
        
        #endregion

        #region Properties

        public string View => _view;
        public float Speed => _speed;

        #endregion

    }

}