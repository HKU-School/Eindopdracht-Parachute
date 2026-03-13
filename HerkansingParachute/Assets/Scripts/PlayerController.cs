using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        /*What I still need, Heallth score system*/

        [Header("Player Value")]
        [SerializeField] private float playerSpeed;

        private Rigidbody2D _rb;
        private Vector2 _moveInput;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
        }

        // Update is called once per frame
        void Update()
        {
            _rb.linearVelocity = new Vector2(_moveInput.x * playerSpeed, _rb.linearVelocity.y);
        }
    }
}
