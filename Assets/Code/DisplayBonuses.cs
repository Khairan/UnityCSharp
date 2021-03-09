using System;
using UnityEngine;
using UnityEngine.UI;


namespace RollABall
{
    public sealed class DisplayBonuses
    {
        #region Fields

        private Text _bonuseLable;
        
        #endregion


        #region Methods

        public DisplayBonuses(GameObject bonus)
        {
            _bonuseLable = bonus.GetComponentInChildren<Text>();
            _bonuseLable.text = String.Empty;
        }
        
        public void Display(int value)
        {
            _bonuseLable.text = $"Набрано очков: {value}";
        }

        #endregion
    }
}