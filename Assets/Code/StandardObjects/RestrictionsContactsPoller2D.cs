using UnityEngine;
using Constants;
using MVC;

namespace StandardObjects
{
    public class RestrictionsContactsPoller2D<T> : IFixedUpdate
        where T : Collider2D
    {

        #region Fields

        private int _contactsCount;

        private T _collider;
        private ContactFilter2D _filter;
        private ContactPoint2D[] _contacts = new ContactPoint2D[Physicals2D.COLLIDER_CONTACTS_AMOUNT];

        #endregion

        #region Properties

        public bool OnTheGround { get; private set; }
        public bool HasLeftContacts { get; private set; }
        public bool HasRightContacts { get; private set; }

        #endregion

        #region Constructors

        public RestrictionsContactsPoller2D(T collider, LayerMask layerMask)
        {

            _collider   = collider;

            _filter     = new ContactFilter2D();
            _filter.SetLayerMask(layerMask);

        }

        #endregion

        #region Interfaces Methods

        public void OnFixedUpdate(float deltaTime)
        {

            OnTheGround         = false;
            HasLeftContacts     = false;
            HasRightContacts    = false;

            _contactsCount      = _collider.GetContacts(_filter, _contacts);

            for(int i = 0; i < _contactsCount; i++)
            {

                var normal              = _contacts[i].normal;
                var rigidbodyContact    = _contacts[i].rigidbody == null;

                if (normal.y > Physicals2D.COLLISION_THRESHOLD)
                    OnTheGround = true;

                if (normal.x > Physicals2D.COLLISION_THRESHOLD && rigidbodyContact)
                    HasLeftContacts = true;

                if (normal.x < 0 - Physicals2D.COLLISION_THRESHOLD && rigidbodyContact)
                    HasRightContacts = true;

            };

        }

        #endregion
        
    }

}