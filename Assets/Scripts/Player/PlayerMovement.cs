using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public static PlayerMovement Singleton;

        private GameControl _gameControl;

        private Rigidbody2D _playerRigidbody;

        private Vector2 _inputVector;

        private Vector2 _direction = new Vector2(1,0);

        private void Awake()
        {
            Singleton = this;
            _playerRigidbody = GetComponent<Rigidbody2D>();

            _gameControl = new GameControl();

            _gameControl.Gameplay.Enable();
            //gameControl.Gameplay.Move.performed += OnMove;
        }

        private void Update()
        {
            _inputVector = _gameControl.Gameplay.Move.ReadValue<Vector2>();
            if (_inputVector != Vector2.zero)
            {
                _direction = _inputVector;
            }
            _playerRigidbody.velocity = _inputVector;
        }

        public Vector2 GetCurrentPlayerPosition()
        {
            return transform.position;
        }

        public bool isMoving()
        {
            return _inputVector != Vector2.zero;
        }

        public Vector2 GetPlayerDirection()
        {
            return _direction;
        }

        public Vector2 GetInputVector2()
        {
            return _inputVector;
        }
    }
}
