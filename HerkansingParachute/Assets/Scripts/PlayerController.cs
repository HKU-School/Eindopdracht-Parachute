using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Value")]
        [SerializeField] private float playerSpeed;

        private Rigidbody2D _rb;
        private Vector2 _moveInput;

        private Animator _animator;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
            MoveAmin();
        }

        // Update is called once per frame
        void Update()
        {
            _rb.linearVelocity = new Vector2(_moveInput.x * playerSpeed, _rb.linearVelocity.y);
        }

        // Animation for moving. 
        private void MoveAmin()
        {
            if (_animator == null)
            {
                return;
            }
            if (_moveInput.x < 0)
            {
                _animator.SetInteger("Movement", -1);
            }
            else if (_moveInput.x > 0)
            {
                _animator.SetInteger("Movement", 1);
            }
            else
            {
                _animator.SetInteger("Movement", 0);
            }
        }
    }
}
