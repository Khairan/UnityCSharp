using System;
using UnityEngine;


namespace RollABall
{
    #region Methods

    public sealed class CaughtPlayerEventArgs : EventArgs
    {
        public Color Color { get; }
        // Можем дописать сколько угодно свойств
        public CaughtPlayerEventArgs(Color color)
        {
            Color = color;
        }

    }
    
    #endregion
}