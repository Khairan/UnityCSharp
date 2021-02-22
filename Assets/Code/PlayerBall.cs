namespace RollABall
{
    public sealed class PlayerBall : Player
    {
        #region UnityMethods

        private void FixedUpdate()
        {
            Move();
        }

        #endregion
    }
}