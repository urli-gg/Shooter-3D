using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float waitTime = 4f;
    public AudioSource audioSource;

    void Start()
    {
        audioSource.Play();

        Invoke("LoadGame", waitTime);
    }

    void LoadGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
