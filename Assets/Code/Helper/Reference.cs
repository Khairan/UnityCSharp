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
        private RenderTexture _miniMapTexture;
        private GameObject _radar;
        private Image _radarImage;

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

        public GameObject Radar
        {
            get
            {
                if (_radar == null)
                {
                    var gameObject = Resources.Load<GameObject>("MiniMap/Radar");
                    _radar = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _radar;
            }
        }

        public Image RadarImage
        {
            get
            {
                if (_radarImage == null)
                {
                    var gameObject = Resources.Load<Image>("MiniMap/RadarObject");
                    _radarImage = Object.Instantiate(gameObject, Radar.transform);
                }

                return _radarImage;
            }
        }

        public RenderTexture MiniMapTexture
        {
            get
            {
                if (_miniMapTexture == null)
                {
                    _miniMapTexture = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");
                }

                return _miniMapTexture;
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