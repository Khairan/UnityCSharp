using UnityEngine;


namespace RollABall
{
    public sealed class MiniMapController : IExecute
    {
        #region Fields

        private Transform _player;
        private Camera _minimapCamera;

        #endregion


        #region Methods
                
        public MiniMapController(Camera miniMapCamera, Transform mainCamera, RenderTexture miniMapTexture)
        {
            _player = mainCamera;
            _minimapCamera = miniMapCamera;
            
            _minimapCamera.transform.parent = null;
            _minimapCamera.transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            _minimapCamera.transform.position = _player.position + new Vector3(0, 5.0f, 0);

            _minimapCamera.GetComponent<Camera>().targetTexture = miniMapTexture;
        }

        public void Execute()
        {
            var newPosition = _player.position;
            newPosition.y = _minimapCamera.transform.position.y;
            _minimapCamera.transform.position = newPosition;
            _minimapCamera.transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
        }

        #endregion
    }
}