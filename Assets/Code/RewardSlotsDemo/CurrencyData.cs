using UnityEngine;

namespace RewardSlotsDemo
{

    public static class CurrencyData
    {

        #region Constants

        public const string Wood = nameof(Wood);
        public const string Gold = nameof(Gold);

        #endregion

        #region Methods

        public static int GetCurrencyAmount(string key)
        {
            
            if (!KeyIsHandled(key)) return default;

            return PlayerPrefs.GetInt(key, 0);

        }

        public static void SetCurrencyAmount(string key, int value)
        {

            if (!KeyIsHandled(key)) return;

            PlayerPrefs.SetInt(key, value);

        }

        public static string GetKeyByRewardType(ERewardType rewardType)
        {

            switch (rewardType)
            {

                case ERewardType.Wood:

                    return Wood;

                case ERewardType.Gold:

                    return Gold;

                default:

                    return default;

            };

        }

        private static bool KeyIsHandled(string key)
        {

            return key == Wood
                || key == Gold;

        }

        #endregion

    }

}