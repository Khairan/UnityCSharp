using UnityEngine;


namespace RollABall
{
    public sealed class PlayerBall : PlayerBase
    {
        #region Fields
        
        private Rigidbody _rigidbody;

        private float _minSpeed = 1.0f;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        #endregion

        
        #region Methods

        public override void Move(float x, float y, float z)
        {
            _rigidbody.AddForce(new Vector3(x, y, z) * Speed);
        }

        public void AddSpeed(float speed)
        {
            try
            {
                Speed += speed;
                if (Speed <= _minSpeed) throw new MyException("Bad speed", Speed);
            }
            catch (MyException exeption)
            {
                Debug.Log($"{exeption.Message} {exeption.Value}");
                Speed = _minSpeed;
            }
        }

        #endregion
    }
}