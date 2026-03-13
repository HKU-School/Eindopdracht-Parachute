using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    [Header("Text field")]
    [SerializeField] private TMP_Text textScore;

    private void Update()
    {
        textScore.text = "Score: " + GameManager.instance.GetScore();
    }
}
