using UnityEngine;

namespace Cars
{

    public class CarView : MonoBehaviour
    {

        #region Fields

        [Header("transforms")]
        [SerializeField] private Transform _cameraTransform;

        [Header("Components")]
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private BoxCollider2D _collider;

        #endregion

        #region Properties

        public Transform CameraTransform => _cameraTransform;
        public Rigidbody2D RigidBody => _rigidbody;
        public BoxCollider2D Collider => _collider;
        
        #endregion

    }

}