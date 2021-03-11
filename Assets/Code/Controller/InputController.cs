using UnityEngine;


namespace RollABall
{
    public sealed class InputController : IExecute
    {
        #region Fields

        private readonly PlayerBase _playerBase;

        #endregion

        
        #region Methods

        public InputController(PlayerBase player)
        {
            _playerBase = player;
        }

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        }

        #endregion
    }
}
