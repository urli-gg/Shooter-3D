using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource menuMusic;

    public void PlayGame()
    {
        menuMusic.Stop();
        SceneManager.LoadScene("Gameplay");
    }

    
    public void OpenCredits()
    {
        menuMusic.Stop();
        SceneManager.LoadScene("Creditos");
    }

    
    public void QuitGame()
    {
        menuMusic.Stop();
        Debug.Log("Salir del juego");

        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
