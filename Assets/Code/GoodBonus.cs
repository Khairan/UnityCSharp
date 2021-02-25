using UnityEngine;
using static UnityEngine.Random;


namespace RollABall
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        #region Fields
        
        public int Point = 1;

        private Material _material;
        private float _lengthFly;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFly = Range(1.0f, 5.0f);
        }

        #endregion


        #region Methods

        protected override void Interaction()
        {
            _view.Display(Point);
            _player.AddSpeed(Range(1.0f, 3.0f));
            base.Interaction();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }

        #endregion
    }
}

