using System;
using UnityEngine;
using UnityEngine.UI;


namespace RollABall
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        #region Fields

        public Text _finishGameLabel;
        public Text _pointsLabel;
        private DisplayEndGame _displayEndGame;

        private ListInteractableObject _interactiveObjects;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObjects = new ListInteractableObject();
            _displayEndGame = new DisplayEndGame(_finishGameLabel);
            var displayBonuses = new DisplayBonuses(_pointsLabel);
            
            foreach (InteractiveObject interactiveObject in _interactiveObjects)
            {
                if (interactiveObject is KillBonus killBonus)
                {
                    killBonus.CaughtPlayer += PauseGame;
                    killBonus.CaughtPlayer += _displayEndGame.GameOver;
                }

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

        private void PauseGame(object o, CaughtPlayerEventArgs args)
        {
            Time.timeScale = 0.0f;
        }

        private void InteractiveObjectOnOnDestroyChange(InteractiveObject value)
        {
            value.OnDestroyChange -= InteractiveObjectOnOnDestroyChange;
            _interactiveObjects.Remove(value);
        }

        public void Dispose()
        {
            foreach (InteractiveObject o in _interactiveObjects)
            {
                if (o is InteractiveObject interactiveObject)
                {
                    Destroy(interactiveObject.gameObject);
                    if (o is KillBonus killBonus)
                    {
                        killBonus.CaughtPlayer -= PauseGame;
                        killBonus.CaughtPlayer -= _displayEndGame.GameOver;
                    }
                }
            }
        }

        #endregion
    }
}