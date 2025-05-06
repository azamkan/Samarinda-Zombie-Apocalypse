using UnityEngine;

public class AttackHitboxEnemy : MonoBehaviour
{
    public int damage = 10;
    public int infection = 20;
    public float attackCooldown = 1.5f;
    private float lastAttackTime;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Time.time >= lastAttackTime + attackCooldown)
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                playerHealth.AddInfection(infection);
                lastAttackTime = Time.time;
            }
        }
    }
}
