using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Pause game
    private bool isPaused = false;
    [SerializeField] private GameObject pauseMenu;

    // Point system 
    private TMP_Text scoreText;
    private int points = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find text and use text
        GameObject textScore = GameObject.Find("Text Score");
        scoreText = textScore.GetComponent<TMP_Text>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    
    // Add point
    public void AddPoint()
    {
        points = points + 1;
        scoreText.text = "Score: " + points;
    }


    public void PauseGame()
    {
        if (isPaused == false)
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseMenu.SetActive(true);
        }
        else if (isPaused == true)
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseMenu.SetActive(false);
        }
    }

}
