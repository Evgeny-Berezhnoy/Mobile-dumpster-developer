using System;
using UnityEngine;
using UnityEngine.Advertisements;
using Game;
using Interfaces;

namespace ProjectAdvertisement
{

    public class AdvertisementDispayer : IAdvertisementDisplayer, IGameStateListener, IDisposableAdvanced
    {

        #region Observers

        private GameStateController _gameStateController;

        #endregion

        #region Interfaces observers

        public GameStateController CurrentGameStateController => _gameStateController;

        #endregion

        #region Interfaces Properties

        public bool IsDisposed { get; private set; }

        #endregion

        #region Constructors

        public AdvertisementDispayer(GameStateController gameStateController)
        {
            
            Advertisement.AddListener(this);

            #if UNITY_EDITOR

            Advertisement.Initialize(AdvertisementKeys.GameID_Android, true);

            #else
                
                Advertisement.Initialize(AdvertisementKeys.GameID_Android);
                
            #endif

            _gameStateController = gameStateController;
            _gameStateController.AddHandler(OnGameStateChange);

        }

        #endregion

        #region Destructors

        ~AdvertisementDispayer()
        {

            Dispose();

        }

        #endregion

        #region Interface Methods

        public void DisplayBanner()
        {

            Advertisement.Show(AdvertisementKeys.Banner_Android);

        }

        public void DisplayInterestitialVideo()
        {

            Advertisement.Show(AdvertisementKeys.Interestitial_Android);
            
        }

        public void DisplayRewardableVideo()
        {

            Advertisement.Show(AdvertisementKeys.Rewarded_Android);
            
        }

        public void OnGameStateChange(EGameState state)
        {

            if (_gameStateController.State == EGameState.MainMenu)
            {

                DisplayInterestitialVideo();
                
            }
            else if (_gameStateController.State == EGameState.Quit)
            {

                Dispose();

            };

        }

        public void OnUnityAdsDidError(string message)
        {

            #if UNITY_EDITOR
                
                Debug.Log($"Failed to display commercial. Error has occured: {message}");
                
            #endif

        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {

            #if UNITY_EDITOR

            if (showResult == ShowResult.Failed)
            {

                Debug.Log($"Failed to display commercial. Error has occured.");

            }
            else if(showResult == ShowResult.Skipped)
            {

                Debug.Log($"Commercial was skipped.");
                
            }
            else
            {

                Debug.Log($"All money of this world upon you.");
                
            };

            #endif

        }

        public void OnUnityAdsDidStart(string placementId)
        {

            // NOTHING TO DO HERE. INTERFACE SEGREGATION PRINCIPLE VIOLATION

        }

        public void OnUnityAdsReady(string placementId)
        {
            
            // NOTHING TO DO HERE. INTERFACE SEGREGATION PRINCIPLE VIOLATION

        }
        
        public virtual void Dispose()
        {

            if (IsDisposed)
            {

                return;

            }

            IsDisposed = true;

            if(_gameStateController != null)
            {

                _gameStateController.RemoveHandler(OnGameStateChange);
                
            };

            Advertisement.RemoveListener(this);

            GC.SuppressFinalize(this);

        }

        #endregion

    }

}