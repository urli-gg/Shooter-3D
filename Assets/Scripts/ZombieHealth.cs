using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int health = 100;
    private WaveManager waveManager;

    void Start()
    {

        waveManager = FindFirstObjectByType<WaveManager>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PointsSystem points = FindFirstObjectByType<PointsSystem>();

        if (points != null)
        {
            points.AddPoints(100); 
        }

        if (waveManager != null)
        {
            waveManager.ZombieKilled();
        }

        Destroy(gameObject);
    }
}

