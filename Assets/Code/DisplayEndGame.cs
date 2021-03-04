using System;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace RollABall
{
    public sealed class DisplayEndGame
    {
        #region Fields
        
        private Text _finishGameLabel;

        #endregion


        #region Methods

        public DisplayEndGame(Text finishGameLabel)
        {
            _finishGameLabel = finishGameLabel;
            _finishGameLabel.text = String.Empty;
        }

        public void GameOver(object o, CaughtPlayerEventArgs args)
        {
            _finishGameLabel.text = $"Вы проиграли. Вас убил {((Object)o).name} {args.Color} цвета";
        }

        #endregion
    }
}