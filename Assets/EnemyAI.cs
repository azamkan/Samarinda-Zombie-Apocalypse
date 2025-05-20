using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectRange = 5f;

    private Transform player;
    private bool isFacingRight = true;

    [Header("Enemy Health")]
    public int maxHealth = 50;
    public int currentHealth;

    [Header("Knockback Settings")]
    public float knockbackForce = 5f;

    [Header("Rigidbody Settings")]
    [SerializeField] private float linearDrag = 4f;
    [SerializeField] private float gravityScale = 3f;
    private Rigidbody2D rb;

    private Animator anim; // Tambahkan animator

    private bool isDead = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = linearDrag;
        rb.gravityScale = gravityScale;

        anim = GetComponent<Animator>(); // Ambil Animator
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectRange)
        {
            FollowPlayer();
            anim.SetBool("run", true); // Berlari jika dalam jarak
        }
        else
        {
            anim.SetBool("run", false); // Tidak berlari jika di luar jarak
        }
    }

    private void FollowPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

        // Flip arah
        if ((direction.x > 0 && !isFacingRight) || (direction.x < 0 && isFacingRight))
        {
            Flip();
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
            return;
        }

        // Knockback
        Vector2 knockbackDir = (transform.position - player.position).normalized;
        rb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
    }

    public void Die()
    {
        isDead = true;
        anim.SetBool("die", true); // Mainkan animasi mati
        Destroy(gameObject,0.5f);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
