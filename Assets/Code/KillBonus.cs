using System;
using UnityEngine;
using static UnityEngine.Random;


namespace RollABall
{
    public sealed class KillBonus : InteractiveObject, IFly
    {
        #region Fields
        
        [SerializeField] private AudioClip _audioSound;
                
        private float _lengthFly;

        private event EventHandler<CaughtPlayerEventArgs> _caughtPlayer;
        public event EventHandler<CaughtPlayerEventArgs> CaughtPlayer
        {
            add { _caughtPlayer += value; }
            remove { _caughtPlayer -= value; }
        }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _lengthFly = Range(1.0f, 5.0f);
        }

        #endregion


        #region Methods

        protected override void Interaction()
        {
            base.Interaction();
            _caughtPlayer?.Invoke(this, new CaughtPlayerEventArgs(_color));
        }

        protected override void PlaySound()
        {
            AudioSource.PlayClipAtPoint(_audioSound, transform.position);
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        #endregion
    }
}

