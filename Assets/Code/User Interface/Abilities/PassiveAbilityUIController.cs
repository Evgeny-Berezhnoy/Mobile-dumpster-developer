using System;
using UnityEngine;
using Interfaces;

using Object = UnityEngine.Object;

namespace UserInterface
{

    public class PassiveAbilityUIController<T> : IButtonChain, IDisposableAdvanced
        where T : UIImage
    {

        #region Constants

        private const string _typeConvertionError = "Couldn't handle chain image. Transfered data is not an AbilitySlidingSlotData";

        #endregion

        #region Fields

        protected T _view;
        protected AbilityUIData _data;

        #endregion

        #region Interfaces Properties

        public bool IsDisposed { get; private set; }

        #endregion

        #region Constructors

        public PassiveAbilityUIController(RectTransform root, T prefab, AbilityUIData data) : this(root, prefab)
        {

            Init(data);

        }

        public PassiveAbilityUIController(RectTransform root, T prefab)
        {

            _view = Object.Instantiate(prefab, root);
            
        }

        public virtual void Dispose()
        {

            if (IsDisposed)
            {

                return;

            };

            IsDisposed = true;

            Object.Destroy(_view);

            GC.SuppressFinalize(this);

        }

        #endregion

        #region Interfaces Methods

        public virtual IButtonChain Handle(IButtonChainData data)
        {

            _data?.UnapplyAction.Invoke();

            var abilityData = data as AbilityUIData;
            
            if(abilityData == null)
            {

                _data               = null;

                _view.Image.sprite  = null;
                
                Debug.LogError(_typeConvertionError);

            }
            else
            {

                Init(abilityData);

            };

            return null;

        }

        public virtual IButtonChain SetNext(IButtonChain buttonChain)
        {

            return null;

        }

        #endregion

        #region Methods

        public virtual void Init(AbilityUIData data)
        {

            _data               = data;

            _view.Image.sprite  = data.Sprite;

            Init();

        }

        public virtual void Init()
        {

            _data?.ApplyAction?.Invoke();

        }

        #endregion

    }

}