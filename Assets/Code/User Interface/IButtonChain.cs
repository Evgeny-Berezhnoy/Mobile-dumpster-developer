namespace UserInterface
{

    public interface IButtonChain
    {

        #region Methods

        IButtonChain Handle(IButtonChainData data);
        IButtonChain SetNext(IButtonChain buttonChain);

        #endregion

    }

}