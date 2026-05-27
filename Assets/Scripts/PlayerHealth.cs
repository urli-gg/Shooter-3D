using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        Debug.Log("Vida: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Has muerto ");
        SceneManager.LoadScene("GameOver");
        
    }
}
