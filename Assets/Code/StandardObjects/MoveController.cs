using UnityEngine;

namespace StandardObjects
{
    public class MoveController : IMovable
    {

        #region Fields

        protected Transform _travelerTransform;
        
        #endregion

        #region Properties

        public float Speed { get; set; }

        public Transform TravelerTransform => _travelerTransform;

        #endregion

        #region Constructors

        public MoveController(Transform transform, float speed)
        {

            _travelerTransform = transform;

            Speed = speed;

        }

        #endregion

        #region Interfaces Methods

        public virtual void Move(Vector3 direction, float deltaTime)
        {

            _travelerTransform.Translate(direction * (deltaTime * Speed));
            
        }

        #endregion

    }

}