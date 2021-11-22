using UnityEngine.Advertisements;

namespace ProjectAdvertisement
{

    public interface IAdvertisementDisplayer : IUnityAdsListener
    {

        #region Methods

        void DisplayInterestitialVideo();
        void DisplayRewardableVideo();
        void DisplayBanner();
        
        #endregion

    }

}