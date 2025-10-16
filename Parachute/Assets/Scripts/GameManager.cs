using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Point system 
    private TMP_Text scoreText;
    private int points = 0;

    // Pause game
    private bool isPaused = false;
    private GameObject pauseMenu;


    private void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find text and use text
        GameObject textScore = GameObject.Find("Text Score");
        scoreText = textScore.GetComponent<TMP_Text>();
        // Find Pause menu
        GameObject menu = GameObject.Find("PauseMenu");
        pauseMenu = menu;
        pauseMenu.SetActive(false);
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

    // Pause game open UI
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
