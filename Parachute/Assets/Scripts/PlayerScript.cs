using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    //// Pause game
    //private bool isPaused = false;
    //[SerializeField] private GameObject pauseMenu;

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
        //PauseGame();
        GameManager.instance.PauseGame();
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
            GameManager.instance.AddPoint();
        }
    }
    //public void PauseGame()
    //{
    //    if (isPaused == false)
    //    {
    //        Time.timeScale = 0;
    //        isPaused = true;
    //        pauseMenu.SetActive(true);
    //    }
    //    else if (isPaused == true)
    //    {
    //        Time.timeScale = 1;
    //        isPaused = false;
    //        pauseMenu.SetActive(false);
    //    }
    //}
}
