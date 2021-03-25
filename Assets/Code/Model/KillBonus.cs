using System;
using UnityEngine;
using static UnityEngine.Random;


namespace RollABall
{
    public sealed class KillBonus : InteractiveObject, IFly
    {
        #region Fields

        public event Action<string, Color> OnCaughtPlayerChange = delegate (string str, Color color) { };

        [SerializeField] private AudioClip _audioSound;

        private float _lengthFly;

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
            OnCaughtPlayerChange.Invoke(gameObject.name, _color);
            base.Interaction();
        }

        protected override void PlaySound()
        {
            AudioSource.PlayClipAtPoint(_audioSound, transform.position);
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Fly();
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

