using UnityEngine;

namespace StandardObjects
{
    public interface IMovable
    {

        #region Properties

        float Speed { get; set; }

        Transform TravelerTransform { get; }
        
        #endregion

        #region Methods

        void Move(Vector3 direction, float deltaTime);

        #endregion

    }

}