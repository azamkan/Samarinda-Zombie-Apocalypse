using UnityEngine;

public class AttackHitboxEnemy : MonoBehaviour
{
    public int damage = 1;
    public int infection = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                playerHealth.AddInfection(infection);
            }
        }
    }
}
