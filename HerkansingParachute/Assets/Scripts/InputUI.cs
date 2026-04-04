using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
public class InputUI : MonoBehaviour
{
    [Header("Icons to show controller")]
    [SerializeField] private GameObject controllerPrefab;
    [SerializeField] private GameObject keyboardPrefab;

    private bool _usingController;

    private void OnEnable()
    {
        InputSystem.onEvent += OnInputEvent;
    }

    private void OnDisable()
    {
        InputSystem.onEvent -= OnInputEvent;
    }

    private void OnInputEvent(InputEventPtr eventPtr, InputDevice device)
    {
        if (device is Gamepad)
        {
            _usingController = true;
        }
        else if (device is Keyboard || device is Mouse)
        {
            _usingController = false;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (controllerPrefab != null)
        {
            controllerPrefab.SetActive(_usingController);
        }
        if (keyboardPrefab != null)
        {
            keyboardPrefab.SetActive(!_usingController);
        }
    }
}
