using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Zombies")]
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;

    [Header("Oleadas")]
    public int waveNumber = 1;
    public int zombiesAlive = 0;
    public float timeBetweenWaves = 5f;

    [Header("Sonido de nueva ronda")]
    public AudioSource audioSource;
    public AudioClip newRoundSound;

    private bool isSpawningWave = false;

    void Start()
    {
        StartWave();
    }

    void Update()
    {
        if (zombiesAlive <= 0 && !isSpawningWave)
        {
            isSpawningWave = true;
            Invoke("NextWave", timeBetweenWaves);
        }
    }

    void StartWave()
    {
        int zombiesToSpawn = waveNumber * 3;

        zombiesAlive = zombiesToSpawn;

        for (int i = 0; i < zombiesToSpawn; i++)
        {
            SpawnZombie();
        }

        isSpawningWave = false;
    }

    void SpawnZombie()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No hay spawn points asignados");
            return;
        }

        Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(zombiePrefab, spawn.position, spawn.rotation);
    }

    void NextWave()
    {
        waveNumber++;

        if (audioSource != null && newRoundSound != null)
        {
            audioSource.PlayOneShot(newRoundSound);
        }

        StartWave();
    }

    public void ZombieKilled()
    {
        zombiesAlive--;
    }
}
