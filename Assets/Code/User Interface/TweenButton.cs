using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Interfaces;

namespace UserInterface
{

    [RequireComponent(typeof(Button))]
    public class TweenButton : MonoBehaviour, IEventHandler<Action>, IDisposableAdvanced
    {

        #region Events

        private event Action _onButtonClick;

        #endregion

        #region Fields

        [Range(1, 0.1f)][SerializeField] private float _minimalScaleMultiplicator = 0.5f;
        [Range(0, 0.5f)][SerializeField] private float _animationDuration = 0.25f;

        private Button _button;

        private Sequence _buttonActionSequince;

        #endregion

        #region Interfaces Properies

        public bool IsDisposed { get; private set; }

        #endregion

        #region Properties

        public bool Interactable
        {

            get => _button.interactable;
            set => _button.interactable = value;

        }

        #endregion

        #region Unity Events

        private void Start()
        {

            IsDisposed = false;

            _buttonActionSequince = DOTween.Sequence();
            
            _button = gameObject.GetComponent<Button>();
            _button.onClick.AddListener(Click);

        }

        private void OnDestroy()
        {

            Dispose();

        }

        private void OnApplicationQuit()
        {

            Dispose();

        }

        #endregion

        #region Interfaces Methods

        public void AddHandler(Action handler)
        {

            _onButtonClick += handler;

        }

        public void RemoveHandler(Action handler)
        {

            _onButtonClick -= handler;

        }
        
        public void RemoveAllHandlers()
        {

            var handlers =
                _onButtonClick
                    ?.GetInvocationList()
                    .ToList()
                    .Cast<Action>()
                    .ToList();

            if (handlers == null)
            {

                return;

            };

            for (int i = 0; i < handlers.Count; i++)
            {

                _onButtonClick -= handlers[i];

            };

        }

        public void Dispose()
        {

            if (IsDisposed) return;

            IsDisposed = true;

            _buttonActionSequince.Kill();
            _buttonActionSequince = null;

            _button?.onClick.RemoveAllListeners();

        }

        #endregion

        #region Methods

        private void Click()
        {

            if (_buttonActionSequince.IsPlaying()) return;

            var localScale = transform.localScale;

            _buttonActionSequince = DOTween.Sequence();
            _buttonActionSequince.AppendCallback(() => _button.interactable = false);
            _buttonActionSequince.Append(transform.DOScale(transform.localScale * _minimalScaleMultiplicator, _animationDuration / 2));
            _buttonActionSequince.Append(transform.DOScale(localScale, _animationDuration / 2));
            _buttonActionSequince.AppendCallback(() => _onButtonClick?.Invoke());
            _buttonActionSequince.AppendCallback(() => _button.interactable = true);

        }

        #endregion

    }

}