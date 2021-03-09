﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace RollABall
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        #region Fields
        
        public PlayerType PlayerType = PlayerType.Ball;
        private ListExecuteObject _executeObjects;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private CameraController _cameraController;
        private InputController _inputController;
        private Reference _reference;

        private int _countBonuses;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _executeObjects = new ListExecuteObject();
            
            _reference = new Reference();

            PlayerBase player = null;
            if (PlayerType == PlayerType.Ball)
            {
                player = _reference.PlayerBall;
            }

            _cameraController = new CameraController(player.transform, _reference.MainCamera.transform);
            _executeObjects.AddExecuteObject(_cameraController);

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(player);
                _executeObjects.AddExecuteObject(_inputController);
            }

            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Bonuse);

            foreach (var o in _executeObjects)
            {
                if (o is KillBonus killBonus)
                {
                    killBonus.OnCaughtPlayerChange += CaughtPlayer;
                    killBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }

                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange += AddBonuse;
                }

                if (o is BadBonus badBonus)
                {
                    badBonus.OnPointChange += AddBonuse;
                }
            }

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);
        }

        private void Update()
        {
            for (var i = 0; i < _executeObjects.Length; i++)
            {
                var interactiveObject = _executeObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }

        #endregion


        #region Methods

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }

        private void CaughtPlayer(string value, Color args)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void AddBonuse(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
        }

        public void Dispose()
        {
            foreach (var o in _executeObjects)
            {
                if (o is KillBonus killBonus)
                {
                    killBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    killBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }

                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonuse;
                }

                if (o is BadBonus badBonus)
                {
                    badBonus.OnPointChange -= AddBonuse;
                }
            }
        }

        #endregion
    }
}