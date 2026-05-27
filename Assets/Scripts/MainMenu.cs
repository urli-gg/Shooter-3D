using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    
    public void OpenCredits()
    {
        SceneManager.LoadScene("Creditos");
    }

    
    public void QuitGame()
    {
        Debug.Log("Salir del juego");

        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
