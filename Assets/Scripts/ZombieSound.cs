using UnityEngine;

public class ZombieSound : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip growlSound;

    [Header("Tiempo entre gruñidos")]
    public float minTime = 3f;
    public float maxTime = 8f;

    void Start()
    {
        StartCoroutine(GrowlRoutine());
    }

    System.Collections.IEnumerator GrowlRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);

            yield return new WaitForSeconds(waitTime);

            PlayGrowl();
        }
    }

    void PlayGrowl()
    {
        if (audioSource != null && growlSound != null)
        {
            audioSource.PlayOneShot(growlSound);
        }
    }
}
