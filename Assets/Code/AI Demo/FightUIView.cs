using TMPro;
using UnityEngine;
using UserInterface;

namespace AIDemo
{

    public class FightUIView : MonoBehaviour
    {

        #region Fields

        [Header("Health")]
        [SerializeField] private TMP_Text _countHealthText;
        [SerializeField] private TweenButton _addHealthButton;
        [SerializeField] private TweenButton _minusHealthButton;
        
        [Header("Power")]
        [SerializeField] private TMP_Text _countPowerText;
        [SerializeField] private TweenButton _addPowerButton;
        [SerializeField] private TweenButton _minusPowerButton;

        [Header("Coins")]
        [SerializeField] private TMP_Text _countMoneyText;
        [SerializeField] private TweenButton _addCoinsButton;
        [SerializeField] private TweenButton _minusCoinsButton;

        [Header("Crime")]
        [Range(0, 10)][SerializeField] private int _crimeThreshold;
        [SerializeField] private TMP_Text _crimeLevelText;
        [SerializeField] private TweenButton _increaseCrimeLevelButton;
        [SerializeField] private TweenButton _decreaseCrimeLevelButton;
        
        [Header("Enemy")]
        [SerializeField] private TMP_Text _countPowerEnemyText;

        [Header("Fight")]
        [SerializeField] private TweenButton _fightButton;
        [SerializeField] private TweenButton _passButton;
        
        #endregion

        #region Properties
        
        public TMP_Text CountHealthText => _countHealthText;
        public TweenButton AddHealthButton => _addHealthButton;
        public TweenButton MinusHealthButton => _minusHealthButton;

        public TMP_Text CountPowerText => _countPowerText;
        public TweenButton AddPowerButton => _addPowerButton;
        public TweenButton MinusPowerButton => _minusPowerButton;

        public TMP_Text CountMoneyText => _countMoneyText;
        public TweenButton AddCoinsButton => _addCoinsButton;
        public TweenButton MinusCoinsButton => _minusCoinsButton;

        public int CrimeThreshold => _crimeThreshold;
        public TMP_Text CrimeLevelText => _crimeLevelText;
        public TweenButton IncreaseCrimeLevelButton => _increaseCrimeLevelButton;
        public TweenButton DecreaseCrimeLevelButton => _decreaseCrimeLevelButton;

        public TMP_Text CountPowerEnemyText => _countPowerEnemyText;
        
        public TweenButton FightButton => _fightButton;
        public TweenButton PassButton => _passButton;

        #endregion

    }

}