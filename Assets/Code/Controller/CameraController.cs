using UnityEngine;


namespace RollABall
{
    public sealed class CameraController : IExecute
    {
        #region Fields

        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _offset;

        #endregion


        #region Methods

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _mainCamera.LookAt(_player);
            _offset = _mainCamera.position - _player.position;
        }

        public void Execute()
        {
            _mainCamera.position = _player.position + _offset;
        }

        #endregion
    }
}
