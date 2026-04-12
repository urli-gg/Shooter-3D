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
        if (waveManager != null)
        {
            waveManager.ZombieKilled();
        }

        Destroy(gameObject);
    }
}
