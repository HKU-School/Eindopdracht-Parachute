using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [Header("Images for lives")]
    [SerializeField] private Image[] hearts;

    private void OnEnable()
    {
        GameManager.instance.OnLivesChanged += UpdateLives;
        UpdateLives(GameManager.instance.GetLives());
    }

    private void OnDisable()
    {
        GameManager.instance.OnLivesChanged -= UpdateLives;
    }

    // Updates UI to current lives
    private void UpdateLives(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < lives;
        }
    }
}
