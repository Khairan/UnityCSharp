using System;
using UnityEngine;
using static UnityEngine.Random;
using static UnityEngine.Debug;


namespace RollABall
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IComparable<InteractiveObject>
    {
        #region Fields

        protected IView _view;
        protected Player _player;
        
        public event Action<InteractiveObject> OnDestroyChange;

        public bool IsInteractable { get; } = true;


        #endregion


        #region UnityMethods

        private void Start()
        {
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

        protected virtual void Interaction()
        {
            Log(_player.ToString());
        }

        public void Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = ColorHSV();
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