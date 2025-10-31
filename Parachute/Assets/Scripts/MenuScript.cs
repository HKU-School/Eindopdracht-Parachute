using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // For the buttons to play/restart/homepage/resume and quit the game.
    public void PlayGame()
    {
        SceneManager.LoadScene("GameLevel");
    }
    public void RestartGame()
    {
        GameManager.instance.PauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void HomePage()
    {
        GameManager.instance.PauseGame();
        SceneManager.LoadScene("MainMenu");
    }
    // Same home page but because of the pause menu I need one to deactivate it
    public void Home2()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    public void Resume()
    {
        GameManager.instance.PauseGame();
    }
    public void Win()
    {
       SceneManager.LoadScene("Win");
    }
    public void Loose()
    {
        SceneManager.LoadScene("Loose");
    }
}
