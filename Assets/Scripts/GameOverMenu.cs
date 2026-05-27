using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    
    public void RetryGame()
    {
        SceneManager.LoadScene("Gameplay");
        Debug.Log("Boton Funcionando");
    }

    
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
