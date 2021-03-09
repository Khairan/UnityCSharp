using UnityEngine;


namespace RollABall
{
    public abstract class PlayerBase : MonoBehaviour
    {
        #region Fields

        public float Speed = 3.0f;

        #endregion


        #region Methods

        public abstract void Move(float x, float y, float z);

        public override string ToString()
        {
            return Speed.ToString();
        }

        #endregion
    }
}
