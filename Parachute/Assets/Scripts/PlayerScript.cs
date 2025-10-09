using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
//using Debug = UnityEngine.Debug; // IDK but if I don't have this I can't do debug.log anymore

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 3f;
    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private bool _isPaused = false;
    
    [SerializeField] private int _Points = 0;
    [SerializeField] private TMP_Text _ScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Checke why horizonMove
        Debug.Log("Move is pressed");
        _moveInput = context.ReadValue<Vector2>();
    }
    public void Pause(InputAction.CallbackContext context)
    {
        // Action for pause game add later. 
        Debug.Log("Pause is pressed");
        PauseGame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_moveInput.x * _playerSpeed, _rb.linearVelocity.y);
    }

    private void PauseGame()
    {
        if (_isPaused == false)
        {
            Time.timeScale = 0;
            _isPaused = true;
        }
        else if (_isPaused == true) 
        {
            Time.timeScale = 1;
            _isPaused = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Parachutisten"))
        {
            _Points = _Points + 1;
            _ScoreText.text = "Score: " + _Points; 
        }
    }
}
