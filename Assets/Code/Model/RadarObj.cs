using UnityEngine;
using UnityEngine.UI;


namespace RollABall
{
    public sealed class RadarObj
    {
        #region Fields

        private Image _ico;
        private GameObject _gameObject;

        #endregion

        
        #region Methods

        public RadarObj(GameObject gameObject)
        {
            _ico = Resources.Load<Image>("MiniMap/RadarObject");
            _gameObject = gameObject;
        }

        public void Disable()
        {
            RadarController.RemoveRadarObject(_gameObject);
        }

        public void Enable()
        {
            RadarController.RegisterRadarObject(_gameObject, _ico);
        }

        #endregion
    }
}