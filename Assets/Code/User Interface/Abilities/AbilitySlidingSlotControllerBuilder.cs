namespace UserInterface
{

    public class AbilitySlidingSlotControllerBuilder : SlidingSlotControllerBuilder<UIButton, AbilityUIData>
    {

        #region Constructors

        public override SlidingSlotController<UIButton, AbilityUIData> Construct(UIButton view, AbilityUIData data)
        {

            return new AbilitySlidingSlotController(view, data);

        }

        public override SlidingSlotController<UIButton, AbilityUIData> Construct(UIButton view)
        {

            return new AbilitySlidingSlotController(view);

        }

        #endregion

    }

}