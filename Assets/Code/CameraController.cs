using UnityEngine;


namespace RollABall
{
    public sealed class CameraController : MonoBehaviour
    {
        #region Fields
        
        public Player Player;
        private Vector3 _offset;

        #endregion


        #region UnityMethods
        
        private void Start()
        {
            _offset = transform.position - Player.transform.position;
        }

        private void LateUpdate()
        {
            transform.position = Player.transform.position + _offset;
        }

        #endregion
    }
}
