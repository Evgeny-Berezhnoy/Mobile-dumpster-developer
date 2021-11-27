using System.Collections.Generic;

namespace AIDemo
{

    public abstract class DataPlayer
    {

        #region Fields

        private string _titleData;
        private int _countMoney;
        private int _countHealth;
        private int _countPower;
        
        private List<IEnemy> _enemies = new List<IEnemy>();

        #endregion

        #region Properties

        public string TitleData => _titleData;
        
        public int Money
        {

            get => _countMoney;
            set
            {

                if (_countMoney != value)
                {

                    _countMoney = value;
                    
                    Notify(DataType.Money);
                
                }
            
            }
        
        }

        public int Health
        {
            
            get => _countHealth;
            set
            {

                if (_countHealth != value)
                {

                    _countHealth = value;
                    
                    Notify(DataType.Health);
                
                }

            }

        }

        public int Power
        {
            
            get => _countPower;
            set
            {

                if (_countPower != value)
                {
                    
                    _countPower = value;
                    
                    Notify(DataType.Power);
                
                }
            
            }
        
        }

        #endregion

        #region Constructors

        protected DataPlayer(string titleData)
        {

            _titleData = titleData;
        
        }

        #endregion

        #region Methods

        public void Attach(IEnemy enemy)
        {

            _enemies.Add(enemy);
        
        }

        public void Detach(IEnemy enemy)
        {
        
            _enemies.Remove(enemy);
        
        }

        protected void Notify(DataType dataType)
        {
        
            foreach (var investor in _enemies)
            {

                investor.Update(this, dataType);

            }

        }

        #endregion

    }

}
