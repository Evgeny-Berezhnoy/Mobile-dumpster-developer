using System.Collections.Generic;
using UnityEngine;
using Abilities;
using Game;

namespace UserInterface
{
    public class AbilitiesSlidingPanelController : SlidingPanelController<UIButton, AbilityUIData>
    {

        #region Fields

        private PassiveAbilityUIController<UIImage> _passiveAbility;
        private ActiveAbilityUIController _activeAbility;

        #endregion

        #region Constructors

        public AbilitiesSlidingPanelController(
            RectTransform root, 
            SlidingPanel prefab, 
            List<AbilityUIData> slotDatas, 
            AbilitySlidingSlotControllerBuilder slotControllerBuilder,
            GameStateController gameStateController,
            List<SlidingSlotController<UIButton, AbilityUIData>> slotControllers,
            PassiveAbilityUIController<UIImage> passiveAbility,
            ActiveAbilityUIController activeAbility) : base(root, prefab, slotDatas, slotControllerBuilder, gameStateController, slotControllers)
        {

            _passiveAbility = passiveAbility;
            _activeAbility  = activeAbility;

            SubscribeSlidingSlots();

        }

        #endregion

        #region Destructors

        ~AbilitiesSlidingPanelController()
        {

            Dispose();

        }

        #endregion

        #region Base Methods

        protected override void SubscribeSlidingSlots()
        {
            
            base.SubscribeSlidingSlots();

            UnsubscribeSlidingSlots();

            for (int i = _slidingSlotCurrentIndex; i < _slidingSlotCurrentIndex + _slidingSlotAmount; i++)
            {
                
                var j = i % _slidingSlotAmount;
                var slotController = (AbilitySlidingSlotController)_slotControllers[j];

                if (i > _slidingSlotDataMaxIndex)
                {

                    slotController.SetSlotData();
                    slotController.SetNext(null);

                    return;

                };

                var slotData        = _slotDatas[i];
                
                if (slotData.Type == EAbilityType.Active)
                {

                    slotController.SetSlotData(slotData);
                    slotController.SetNext(_activeAbility);

                }
                else
                {

                    slotController.SetSlotData(slotData);
                    slotController.SetNext(_passiveAbility);
                    
                };

            };

        }

        protected override void UnsubscribeSlidingSlots()
        {
            
            base.UnsubscribeSlidingSlots();


            for (int i = 0; i < _slotControllers.Count; i++)
            {

                var slotController = (AbilitySlidingSlotController)_slotControllers[i];

                slotController.SetSlotData();
                slotController.SetNext(null);

            };


        }

        public override void Dispose()
        {

            if (IsDisposed)
            {

                return;

            }

            _passiveAbility.Dispose();
            _activeAbility.Dispose();

            base.Dispose();

        }

        #endregion

    }

}
