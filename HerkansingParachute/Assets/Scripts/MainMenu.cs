using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("GamePlay");
        }

        public void QuitGame()
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }

        public void BackMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

