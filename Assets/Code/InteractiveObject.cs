using System;
using UnityEngine;
using static UnityEngine.Random;
using static UnityEngine.Debug;
using UnityEngine.Events;

namespace RollABall
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IComparable<InteractiveObject>
    {
        #region Fields

        protected IView _view;
        protected Player _player;
        protected Color _color;

        public event Action<InteractiveObject> OnDestroyChange;
        public UnityEvent BonusEvent;

        public bool IsInteractable { get; } = true;

        #endregion


        #region UnityMethods

        private void Start()
        {
            BonusEvent = new UnityEvent();
            BonusEvent.AddListener(PlaySound);
            Action();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            _player = other.GetComponent<Player>();
            Interaction();
            OnDestroyChange?.Invoke(this);
            Destroy(gameObject);
        }

        #endregion


        #region Methods

        protected abstract void PlaySound();

        protected virtual void Interaction()
        {
            Log(_player.ToString());
            BonusEvent.Invoke();
        }

        public void Action()
        {
            _color = ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }

        public void Initialization(IView view)
        {
            _view = view;
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Color.cyan;
            }
        }

        public int CompareTo(InteractiveObject other)
        {
            return name.CompareTo(other.name);
        }

        #endregion
    }
}