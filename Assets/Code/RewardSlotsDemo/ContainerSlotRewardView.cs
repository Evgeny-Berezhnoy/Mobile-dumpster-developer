using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RewardSlotsDemo
{

    public class ContainerSlotRewardView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private Image _selectBackground;
        [SerializeField] private Image _iconCurrency;
        [SerializeField] private TMP_Text _textDays;
        [SerializeField] private TMP_Text _countReward;

        #endregion

        #region Methods

        public void SetData(Reward reward, int countDay, bool isSelect)
        {

            _iconCurrency.sprite = reward.IconCurrency;
            _textDays.text = $"Day {countDay}";
            _countReward.text = reward.CountCurrency.ToString();
            _selectBackground.gameObject.SetActive(isSelect);
        
        }

        #endregion

    }

}