using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    [Header("Text field")]
    [SerializeField] private TMP_Text textScore;

    private void Awake()
    {
        textScore.text = "Score: 0";
    }

    private void OnEnable()
    {
        GameManager.instance.OnScoreChange += UpdateScore;
    }

    private void OnDisable()
    {
        GameManager.instance.OnScoreChange -= UpdateScore;
    }

    private void UpdateScore(int newScore)
    {
        textScore.text = "Score: " + newScore;
    }
}
