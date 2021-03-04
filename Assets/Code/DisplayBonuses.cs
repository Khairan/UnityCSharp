using UnityEngine.UI;
using UnityEngine;


namespace RollABall
{
    public sealed class DisplayBonuses: IView
    {
        #region Fields

        private Text _text;
        private int _points;

        #endregion


        #region Methods

        public DisplayBonuses(Text pointsLabel)
        {
            _text = pointsLabel;
        }

        public void Display(int value)
        {
            _points += value;
            _text.text = $"Набрано очков: {_points}";
        }

        #endregion
    }
}