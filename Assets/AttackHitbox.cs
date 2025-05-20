using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public int damage = 30;
    private Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // misalnya enemy punya metode TakeDamage()
            collision.GetComponent<EnemyAI>().TakeDamage(damage);
        }
    }
}
