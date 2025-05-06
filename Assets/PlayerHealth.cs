using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxInfection = 100;
    public int currentHealth;
    public int currentInfection;

    private void Start()
    {
        currentHealth = maxHealth;
        currentInfection = 0;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void AddInfection(int amount)
    {
        currentInfection += amount;
        if (currentInfection >= maxInfection)
        {
            Die();
        }
    }

    public void RestoreHP(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }

    public void CureInfection(int amount)
    {
        currentInfection = Mathf.Max(currentInfection - amount, 0);
    }

    private void Die()
    {
        Debug.Log("Player Dead");
        // Tambah animasi mati atau scene restart
    }
}
