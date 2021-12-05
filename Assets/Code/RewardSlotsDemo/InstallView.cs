using UnityEngine;

namespace RewardSlotsDemo
{

    public class InstallView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private DailyRewardView _dailyRewardView;

        private DailyRewardController _dailyRewardController;

        #endregion

        #region Unity events

        private void Awake()
        {
            _dailyRewardController = new DailyRewardController(_dailyRewardView);
        }

        private void Start()
        {
            _dailyRewardController.RefreshView();
        }

        #endregion

    }

}