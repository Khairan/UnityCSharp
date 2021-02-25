using System;
using UnityEngine;


namespace RollABall
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        #region Fields

        private ListInteractableObject _interactiveObjects;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObjects = new ListInteractableObject();
            var displayBonuses = new DisplayBonuses();
            foreach (InteractiveObject interactiveObject in _interactiveObjects)
            {
                interactiveObject.Initialization(displayBonuses);
                interactiveObject.OnDestroyChange += InteractiveObjectOnOnDestroyChange;
            }
        }

        private void Update()
        {
            foreach (InteractiveObject interactiveObject in _interactiveObjects)
            {
                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFly fly)
                {
                    fly.Fly();
                }
                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }
                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }

        #endregion


        #region Methods

        private void InteractiveObjectOnOnDestroyChange(InteractiveObject value)
        {
            value.OnDestroyChange -= InteractiveObjectOnOnDestroyChange;
            _interactiveObjects.Remove(value);
        }

        public void Dispose()
        {
            foreach (InteractiveObject o in _interactiveObjects)
            {
                Destroy(o.gameObject);
            }
        }

        #endregion
    }
}