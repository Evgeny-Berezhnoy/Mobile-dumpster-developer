using UnityEngine;

namespace AIDemo
{

    public class Enemy : IEnemy
    {

        #region Constants

        private const int _ownPower = 3;

        #endregion

        #region Fields

        private string _name;
        private int _moneyPlayer;
        private int _healthPlayer;
        private int _powerPlayer;

        #endregion

        #region Properties
        
        public int Power
        {

            get
            {

                var _powerPlayerSafe = (_powerPlayer == 0) ? 1 : _powerPlayer; 
                var enemyGreedFury = _moneyPlayer / _powerPlayerSafe + _healthPlayer + _ownPower;
                
                return enemyGreedFury;

            }

        }

        #endregion

        #region Constructors

        public Enemy(string name)
        {

            _name = name;

        }

        #endregion

        #region Methods

        public void Update(DataPlayer dataPlayer, DataType dataType)
        {

            switch (dataType)
            {

                case DataType.Money:
                    _moneyPlayer = dataPlayer.Money;
                    break;

                case DataType.Health:
                    _healthPlayer = dataPlayer.Health;
                    break;

                case DataType.Power:
                    _powerPlayer = dataPlayer.Power;
                    break;

            }

            Debug.Log($"Notified {_name} change to {dataPlayer}");

        }

        #endregion
        
    }
    
}