using System.Diagnostics;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug; // IDK but if I don't have this I can't do debug.log anymore

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 3f;
    private Rigidbody2D _rb;
    private float _horizonMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Checke why horizonMove
        Debug.Log("Move is pressed");
    }
    public void Pause(InputAction.CallbackContext context)
    {
        // Action for pause game add later. 
        Debug.Log("Pause is pressed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
