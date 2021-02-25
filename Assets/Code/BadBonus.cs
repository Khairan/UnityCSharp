using UnityEngine;
using static UnityEngine.Random;


namespace RollABall
{
    public sealed class BadBonus : InteractiveObject, IFly, IRotation
    {
        #region Fields

        public int Point = -1;

        private float _lengthFly;
        private float _speedRotation;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _lengthFly = Range(1.0f, 5.0f);
            _speedRotation = Range(10.0f, 50.0f);
        }

        #endregion


        #region Methods

        protected override void Interaction()
        {
            _view.Display(Point);
            _player.AddSpeed(Range(-1.0f, -2.0f));
            base.Interaction();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        #endregion
    }
}

