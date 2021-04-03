using UnityEngine;
using UnityEngine.UI;


namespace RollABall
{
    public class Reference
    {
        #region Fields
        
        private PlayerBall _playerBall;
        private Camera _mainCamera;
        private Camera _miniMapCamera;
        private Canvas _canvas;
        private GameObject _bonuse;
        private GameObject _endGame;
        private Button _restartButton;
        private GameObject _miniMap;

        private string _miniMapCameraName = "MinimapCamera";

        #endregion


        #region Properties

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        public GameObject Bonuse
        {
            get
            {
                if (_bonuse == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Bonuse");
                    _bonuse = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _bonuse;
            }
        }

        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/EndGame");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _endGame;
            }
        }

        public GameObject MiniMap
        {
            get
            {
                if (_miniMap == null)
                {
                    var gameObject = Resources.Load<GameObject>("MiniMap/MiniMap");
                    _miniMap = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _miniMap;
            }
        }

        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _restartButton;
            }
        }

        public PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var gameObject = Resources.Load<PlayerBall>("Player");
                    _playerBall = Object.Instantiate(gameObject);
                }

                return _playerBall;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }

        public Camera MiniMapCamera
        {
            get
            {
                if (_miniMapCamera == null)
                {
                    foreach (var camera in Camera.allCameras)
                    {
                        if (camera.name == _miniMapCameraName) _miniMapCamera = camera;
                        break;
                    }
                }
                return _miniMapCamera;
            }
        }

    #endregion

}
}