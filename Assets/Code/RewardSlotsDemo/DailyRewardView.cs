using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RewardSlotsDemo
{

    public class DailyRewardView : MonoBehaviour
    {

        #region Constants

        private const string CurrentSlotInActiveKey = nameof(CurrentSlotInActiveKey);
        private const string TimeGetRewardKey = nameof(TimeGetRewardKey);

        #endregion

        #region Fields

        [Header("Settings Time Get Reward")]
        [SerializeField] private float _timeCooldown = 86400;
        [SerializeField] private float _timeDeadline = 172800;

        [Header("Settings Rewards")]
        [SerializeField] private List<Reward> _rewards;

        [Header("Ui Elements")]
        [SerializeField] private TMP_Text _timerNewReward;
        [SerializeField] private Transform _mountRootSlotsReward;
        [SerializeField] private ContainerSlotRewardView _containerSlotRewardView;
        [SerializeField] private Button _getRewardButton;
        [SerializeField] private Image _getRewardProgressBar;
        [SerializeField] private Button _resetButton;

        #endregion

        #region Properties

        public float TimeCooldown => _timeCooldown;
        public float TimeDeadline => _timeDeadline;
        public List<Reward> Rewards => _rewards;
        public TMP_Text TimerNewReward => _timerNewReward;
        public Transform MountRootSlotsReward => _mountRootSlotsReward;
        public ContainerSlotRewardView ContainerSlotRewardView => _containerSlotRewardView;
        public Button GetRewardButton => _getRewardButton;
        public Image GetRewardProgressBar => _getRewardProgressBar;
        public Button ResetButton => _resetButton;

        public int CurrentSlotInActive
        {

            get => PlayerPrefs.GetInt(CurrentSlotInActiveKey, 0);
            set => PlayerPrefs.SetInt(CurrentSlotInActiveKey, value);
        
        }

        public DateTime? TimeGetReward
        {

            get
            {

                var data = PlayerPrefs.GetString(TimeGetRewardKey, null);

                if (!string.IsNullOrEmpty(data)) return DateTime.Parse(data);

                return null;

            }
            set
            {

                if (value != null)
                    PlayerPrefs.SetString(TimeGetRewardKey, value.ToString());
                else
                    PlayerPrefs.DeleteKey(TimeGetRewardKey);

            }
        }

        #endregion

        #region Unity events

        private void OnDestroy()
        {
            
            _getRewardButton.onClick.RemoveAllListeners();
            _resetButton.onClick.RemoveAllListeners();
        
        }

        #endregion

    }

}