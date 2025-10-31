using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private MenuScript menuScript;

    // Pause game
    private bool isPaused = false;
    [SerializeField] private GameObject pauseMenu;

    // Point system 
    private TMP_Text scoreText;
    public int points = 0;
    [SerializeField] int maxPoints = 15;
    [SerializeField] int minesPoints = 1;

    private int dogPoints;
    [SerializeField] int maxDogPoints = 3;
    

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Get the menu script.
        menuScript = GetComponent<MenuScript>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find text and use text
        GameObject textScore = GameObject.Find("Text Score");
        scoreText = textScore.GetComponent<TMP_Text>();
    }

    // Add point
    public void AddPoint()
    {
        points = points + 1;
        scoreText.text = "Score: " + points;

        // When max points reach you win
        if (points >= maxPoints)
        {
            menuScript.Win();
        }
    }

    // Remove point 
    public void DogPoint()
    {
        // Add dog cach if you have the max you loose the game.
        dogPoints = dogPoints + 1;
        if (dogPoints >= maxDogPoints)
        {
            menuScript.Loose();
        }
        // Remove points 
        if (points > 0)
        {
            points = points - minesPoints;
            scoreText.text = "Score: " + points;
        }
    }
    public void RemovePoint()
    { 
        // Remove point
        if (points > 0)
        {
            points = points - minesPoints;
            scoreText.text = "Score: " + points;
        }
    }

    // Pause menu
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
