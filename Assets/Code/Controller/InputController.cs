using UnityEngine;


namespace RollABall
{
    public sealed class InputController : IExecute
    {
        #region Fields

        private readonly PlayerBase _playerBase;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly PhotoController _photoController;

        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;
        private readonly KeyCode _screenshot = KeyCode.P;

        #endregion


        #region Methods

        public InputController(PlayerBase player)
        {
            _playerBase = player;

            _saveDataRepository = new SaveDataRepository();
            _photoController = new PhotoController();
        }

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(_savePlayer))
            {
                _saveDataRepository.Save(_playerBase);
            }
            if (Input.GetKeyDown(_loadPlayer))
            {
                _saveDataRepository.Load(_playerBase);
            }
            if (Input.GetKeyDown(_screenshot))
            {
                _photoController.CaptureScreenshot();
            }
        }

        #endregion
    }
}
