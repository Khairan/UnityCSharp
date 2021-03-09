using System;
using UnityEngine;
using UnityEngine.UI;


namespace RollABall
{
    public sealed class DisplayEndGame
    {
        #region Fields
        
        private Text _finishGameLabel;

        #endregion


        #region Methods

        public DisplayEndGame(GameObject endGame)
        {
            _finishGameLabel = endGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
        }
        
        public void GameOver(string name, Color color)
        {
            _finishGameLabel.text = $"Вы проиграли. Вас убил {name} {color} цвета";
        }

        #endregion
    }
}