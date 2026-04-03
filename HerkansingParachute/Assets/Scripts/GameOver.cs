using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("UI screen overlay")]
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject gameScreen;

    private void Start()
    {
        GameManager.instance.OnGameOver += ShowDeathScreen;
    }

    private void OnDisable()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnGameOver -= ShowDeathScreen;
        }
    }

    private void ShowDeathScreen()
    {
        gameScreen. SetActive(false);
        deathScreen.SetActive(true);
    }
}
