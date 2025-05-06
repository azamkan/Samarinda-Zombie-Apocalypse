using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // misalnya enemy punya metode TakeDamage()
            collision.GetComponent<EnemyAI>().TakeDamage(10);
        }
    }
}
