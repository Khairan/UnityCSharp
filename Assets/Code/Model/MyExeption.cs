using System;


namespace RollABall
{
    public sealed class MyException : Exception
    {
        #region Fields

        public float Value { get; }

        #endregion


        #region Methods

        public MyException(string message, float val) : base(message)
        {
            Value = val;
        }

        #endregion
    }
}