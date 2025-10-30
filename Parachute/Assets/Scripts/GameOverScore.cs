using TMPro;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{
    private TMP_Text highText;

    void Start()
    {
        int endScore = GameManager.instance.points;
        Debug.Log(GameManager.instance.points);

        // Find text and use text
        GameObject textScore = GameObject.Find("High Score");
        highText = textScore.GetComponent<TMP_Text>();

        highText.text = ": " + endScore;
    }

    private void Update()
    {
        
    }
}
