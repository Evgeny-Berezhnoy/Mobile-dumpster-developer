using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UserInterface;

namespace RewardSlotsDemo
{

    public class DailyRewardView : MonoBehaviour
    {

        #region Fields

        [Header("Settings Time Get Reward")]
        [SerializeField] private float _timeCooldown = 86400;
        [SerializeField] private float _timeDeadline = 172800;

        [Header("Settings Rewards")]
        [SerializeField] private List<Reward> _rewards;
        [SerializeField] private RectTransform _woodRewardPosition;
        [SerializeField] private RectTransform _goldRewardPosition;
        [SerializeField] private Sprite _woodSprite;
        [SerializeField] private Sprite _goldSprite;
        
        [Header("Ui Elements")]
        [SerializeField] private TMP_Text _timerNewReward;
        [SerializeField] private RectTransform _mountRootSlotsReward;
        [SerializeField] private ContainerSlotRewardView _containerSlotRewardView;
        [SerializeField] private TweenButton _getRewardButton;
        [SerializeField] private Image _getRewardProgressBar;
        [SerializeField] private TweenButton _resetButton;
        [SerializeField] private TweenButton _mainMenuButton;
        
        #endregion

        #region Properties

        public float TimeCooldown => _timeCooldown;
        public float TimeDeadline => _timeDeadline;
        public List<Reward> Rewards => _rewards;
        public RectTransform WoodRewardPosition => _woodRewardPosition;
        public RectTransform GoldRewardPosition => _goldRewardPosition;
        public Sprite WoodSprite => _woodSprite;
        public Sprite GoldSprite => _goldSprite;
        public TMP_Text TimerNewReward => _timerNewReward;
        public RectTransform MountRootSlotsReward => _mountRootSlotsReward;
        public ContainerSlotRewardView ContainerSlotRewardView => _containerSlotRewardView;
        public TweenButton GetRewardButton => _getRewardButton;
        public Image GetRewardProgressBar => _getRewardProgressBar;
        public TweenButton ResetButton => _resetButton;
        public TweenButton MainMenuButton => _mainMenuButton;

        #endregion

    }

}