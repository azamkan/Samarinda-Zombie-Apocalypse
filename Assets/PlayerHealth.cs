using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxInfection = 100;
    public int currentHealth;
    public int currentInfection;

    public Slider healthSlider;

    public Slider infectionSlider;

    public void SetMaxhealth()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void Sethealth()
    {
        healthSlider.value = currentHealth;
    }

    public void SetMaxinfection()
    {
        infectionSlider.maxValue = maxInfection;
        infectionSlider .value = currentInfection;
    }

    public void Setinfection()
    {
        infectionSlider.value = currentInfection;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        currentInfection = 0;
        Setinfection();
        Sethealth();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Sethealth();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void AddInfection(int amount)
    {
        currentInfection += amount;
        Setinfection();
        if (currentInfection >= maxInfection)
        {
            Die();
        }
    }

    public void RestoreHP(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Sethealth();
    }

    public void CureInfection(int amount)
    {
        currentInfection = Mathf.Max(currentInfection - amount, 0);
        Setinfection();
    }

    private void Die()
    {
        Debug.Log("Player Dead");
        // Tambah animasi mati atau scene restart
        SceneManager.LoadScene("gameover");
    }
}
