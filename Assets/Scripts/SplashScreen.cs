using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float waitTime = 3f;

    void Start()
    {
        Invoke("LoadGame", waitTime);
    }

    void LoadGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
