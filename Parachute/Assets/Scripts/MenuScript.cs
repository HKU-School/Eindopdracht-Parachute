using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.Instance.PauseGame();
        Debug.Log("PlayGame");
        SceneManager.LoadScene("GameLevel");
    }
    public void HomePage()
    {
        Debug.Log("HomePage");
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
