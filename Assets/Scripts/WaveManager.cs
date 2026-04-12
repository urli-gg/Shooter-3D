using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;

    public int waveNumber = 1;
    public int zombiesAlive = 0;

    public float timeBetweenWaves = 5f;

    private bool isSpawningWave = false; // 🔥 clave

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
        if (spawnPoints.Length == 0) return;

        Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(zombiePrefab, spawn.position, spawn.rotation);
    }

    void NextWave()
    {
        waveNumber++;
        StartWave();
    }

    public void ZombieKilled()
    {
        zombiesAlive--;
    }
}
