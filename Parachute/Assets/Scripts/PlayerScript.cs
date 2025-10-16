using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Checke why horizonMove
        Debug.Log("Move is pressed");
        moveInput = context.ReadValue<Vector2>();
    }

    public void Pause(InputAction.CallbackContext context)
    {
        // Action for pause game add later. 
        Debug.Log("Pause is pressed");
        GameManager.Instance.PauseGame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * playerSpeed, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Parachutisten"))
        {
            GameManager.Instance.AddPoint();
        }
    }

}
