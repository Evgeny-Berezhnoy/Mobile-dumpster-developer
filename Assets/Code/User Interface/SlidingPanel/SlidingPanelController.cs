using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Game;
using Interfaces;
using MVC;

using Object = UnityEngine.Object; 

namespace UserInterface
{

    public class SlidingPanelController<T1, T2> : IController, IGameStateListener, IToggleObject, IDisposableAdvanced
        where T1 : MonoBehaviour
        where T2 : ISlidingSlotData
    {

        #region Fields

        protected SlidingPanel _view;
        protected RectTransform _slidingSlotsTransform;

        protected int _slidingSlotCurrentIndex;
        protected int _slidingSlotAmount;
        protected int _slidingSlotDataMaxIndex;

        protected List<T2> _slotDatas;
        protected List<SlidingSlotController<T1, T2>> _slotControllers;

        protected bool _isEnabled;

        #endregion

        #region Interfaces Properties

        public bool IsDisposed { get; private set; }

        #endregion

        #region Interfaces observers

        public GameStateController CurrentGameStateController { get; private set; }

        #endregion

        #region Constructors

        public SlidingPanelController(RectTransform root, SlidingPanel prefab, List<T2> slotDatas, SlidingSlotControllerBuilder<T1, T2> slotControllerBuilder, GameStateController gameStateController, List<SlidingSlotController<T1, T2>> slotControllers)
        {

            _view = Object.Instantiate(prefab, root);
            
            _view.HideShowButton.onClick.AddListener(SwitchOn);
            _view.SlideBackButton.onClick.AddListener(MovePanelSlotsBack);
            _view.SlideForthButton.onClick.AddListener(MovePanelSlotsForth);

            _slidingSlotsTransform      = _view.SlotsPanel;

            _slidingSlotCurrentIndex    = 0;
            _slidingSlotAmount          = _view.Slots.Count;
            _slidingSlotDataMaxIndex    = slotDatas.Count - 1;

            _slotDatas = slotDatas;

            for (int i = 0; i < _slidingSlotAmount; i++)
            {

                var slotView = _view.Slots[i] as T1;

                slotControllers.Add(slotControllerBuilder.Construct(slotView));

            };

            _slotControllers            = slotControllers;

            CurrentGameStateController  = gameStateController;
            CurrentGameStateController.AddHandler(OnGameStateChange);

            SubscribeSlidingSlots();

        }

        #endregion

        #region Destructors

        ~SlidingPanelController()
        {

            Dispose();

        }

        #endregion

        #region Interfaces Methods

        public virtual void OnGameStateChange(EGameState state)
        {

            switch (state)
            {

                case EGameState.Quit:

                    Dispose();

                    break;

                default:

                    SwitchOff();

                    break;

            };

        }

        public virtual void SwitchOff()
        {

            if (!_isEnabled) return;

            _isEnabled = false;

            _view.HideShowButton.onClick.RemoveAllListeners();
            _view.HideShowButton.onClick.AddListener(SwitchOn);

            _slidingSlotsTransform.DOLocalMoveX(_view.SlideDistance, _view.SlideDelay);

        }

        public virtual void SwitchOn()
        {

            if (_isEnabled) return;

            _isEnabled = true;

            _view.HideShowButton.onClick.RemoveAllListeners();
            _view.HideShowButton.onClick.AddListener(SwitchOff);

            _slidingSlotsTransform.DOLocalMoveX(_view.SlideDistance, _view.SlideDelay);
            
        }

        public virtual void Dispose()
        {

            if (IsDisposed)
            {

                return;

            };

            IsDisposed = true;

            CurrentGameStateController?.RemoveHandler(OnGameStateChange);

            _view.HideShowButton.onClick.RemoveAllListeners();
            _view.SlideBackButton.onClick.RemoveAllListeners();
            _view.SlideForthButton.onClick.RemoveAllListeners();

            UnsubscribeSlidingSlots();

            for (int i = 0; i < _slotControllers.Count; i++)
            {

                _slotControllers[i].Dispose();

            };

            Object.Destroy(_view);

            GC.SuppressFinalize(this);

        }

        #endregion

        #region Methods

        protected virtual void MovePanelSlotsForth()
        {

            if(_slidingSlotCurrentIndex + _slidingSlotAmount > _slidingSlotDataMaxIndex)
            {

                return;

            };

            _slidingSlotCurrentIndex += _slidingSlotAmount;

            SubscribeSlidingSlots();

        }

        protected virtual void MovePanelSlotsBack()
        {

            if (_slidingSlotCurrentIndex - _slidingSlotAmount < 0)
            {

                return;

            };

            _slidingSlotCurrentIndex -= _slidingSlotAmount;

            SubscribeSlidingSlots();

        }

        protected virtual void SubscribeSlidingSlots()
        {

            UnsubscribeSlidingSlots();
            
            for (int i = _slidingSlotCurrentIndex; i < _slidingSlotCurrentIndex + _slidingSlotAmount; i++)
            {

                if (i > _slidingSlotDataMaxIndex) return;

                var j               = i % _slidingSlotAmount;
                
                var slotData        = _slotDatas[i];
                var slotController  = _slotControllers[j];

                slotController.SetSlotData(slotData);
                
            };

        }

        protected virtual void UnsubscribeSlidingSlots()
        {

            for(int i = 0; i < _slotControllers.Count; i++)
            {
                
                var slotController = _slotControllers[i];

                slotController.SetSlotData();
                
            };

        }

        #endregion

    }

}