using UnityEngine;
using static UnityEngine.Random;
using static UnityEngine.Debug;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RollABall
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        #region Fields

        protected PlayerBall _player;
        protected Color _color;

        private RadarObj _radarObj;

        public UnityEvent BonusEvent;

        public bool _isInteractable;

        protected bool IsInteractable
        {
            get { return _isInteractable; }
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        #endregion


        #region UnityMethods

        private void Start()
        {
            IsInteractable = true;
            _color = ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }

            BonusEvent = new UnityEvent();
            BonusEvent.AddListener(PlaySound);
            _radarObj = new RadarObj(gameObject);
            _radarObj.Enable();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            _player = other.GetComponent<PlayerBall>();
            Interaction();
            IsInteractable = false;
            _radarObj.Disable();
        }

        #endregion


        #region Methods

        public abstract void Execute();

        protected abstract void PlaySound();

        protected virtual void Interaction()
        {
            Log(_player.ToString());
            BonusEvent.Invoke();
        }

        #endregion
    }
}