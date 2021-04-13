using UnityEngine;
using static UnityEngine.Random;
using static UnityEngine.Debug;
using UnityEngine.Events;


namespace RollABall
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        #region Fields

        [SerializeField] private bool _isAllowScaling;
        [Range(0, 3)]
        [SerializeField] private float ActiveDis;

        protected PlayerBall _player;
        protected Color _color;

        private RadarObj _radarObj;

        [Space(20)]
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
            _radarObj = new RadarObj(this);
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

        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "bot.jpg", _isAllowScaling);
        }

        private void OnDrawGizmosSelected()
        {
            #if UNITY_EDITOR
            Transform t = transform;

            //Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, t.localScale);
            //Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

            var flat = new Vector3(ActiveDis, 0, ActiveDis);
            Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, flat);
            Gizmos.DrawWireSphere(Vector3.zero, 5);
            #endif
        }

        #endregion
    }
}