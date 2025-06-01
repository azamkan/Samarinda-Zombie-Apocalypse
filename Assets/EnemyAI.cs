using System;
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

    [Header("Attack Settings")]
    public float attackRange = 2f;
    public GameObject attackHitbox;
    public float attackCooldown = 3.5f;
    public float attackDuration = 0.2f;
    private float lastAttackTime;

    private Animator anim;
    private bool isDead = false;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = linearDrag;
        rb.gravityScale = gravityScale;
        anim = GetComponent<Animator>();

        if (attackHitbox != null)
            attackHitbox.SetActive(false);
    }

    private void Update()
    {
        if (isDead || player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        //Debug.Log(distance);

        if (distance <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
        }
        else if (distance <= detectRange)
        {
            FollowPlayer();
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }
    }

    private void Attack()
    {
        Debug.Log("serang");
        anim.SetTrigger("attack");
        lastAttackTime = Time.time;

        if (attackHitbox != null)
            attackHitbox.SetActive(true);

        Invoke(nameof(DisableAttackHitbox), attackDuration);
    }

    private void DisableAttackHitbox()
    {
        if (attackHitbox != null)
            attackHitbox.SetActive(false);
    }

    private void FollowPlayer()
    {
        audioManager.PlayZombieSound();
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

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

        Vector2 knockbackDir = (transform.position - player.position).normalized;
        rb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
    }

    public void Die()
    {
        isDead = true;
        anim.SetBool("die", true);
        Destroy(gameObject, 0.5f);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}




//using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
//public class EnemyAI : MonoBehaviour
//{
//    public float moveSpeed = 2f;
//    public float detectRange = 5f;

//    private Transform player;
//    private bool isFacingRight = true;

//    [Header("Enemy Health")]
//    public int maxHealth = 50;
//    public int currentHealth;

//    [Header("Knockback Settings")]
//    public float knockbackForce = 5f;

//    [Header("Rigidbody Settings")]
//    [SerializeField] private float linearDrag = 4f;
//    [SerializeField] private float gravityScale = 3f;
//    private Rigidbody2D rb;

//    [Header("Attack Settings")]
//    public float attackRange = 0.5f;
//    public GameObject attackHitbox;

//    private Animator anim; // Tambahkan animator

//    private bool isDead = false;

//    private void Start()
//    {
//        player = GameObject.FindGameObjectWithTag("Player").transform;
//        currentHealth = maxHealth;
//        rb = GetComponent<Rigidbody2D>();
//        rb.linearDamping = linearDrag;
//        rb.gravityScale = gravityScale;

//        anim = GetComponent<Animator>(); // Ambil Animator
//    }

//    private void Update()
//    {
//        if (isDead) return;

//        float distance = Vector2.Distance(transform.position, player.position);

//        if (distance <= detectRange)
//        {
//            FollowPlayer();
//            anim.SetBool("run", true); // Berlari jika dalam jarak
//        }
//        else
//        {
//            anim.SetBool("run", false); // Tidak berlari jika di luar jarak
//        }
//    }

//    private void FollowPlayer()
//    {
//        Vector2 direction = (player.position - transform.position).normalized;
//        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

//        // Flip arah
//        if ((direction.x > 0 && !isFacingRight) || (direction.x < 0 && isFacingRight))
//        {
//            Flip();
//        }
//    }

//    public void TakeDamage(int amount)
//    {
//        currentHealth -= amount;
//        if (currentHealth <= 0)
//        {
//            Die();
//            return;
//        }

//        // Knockback
//        Vector2 knockbackDir = (transform.position - player.position).normalized;
//        rb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
//    }

//    public void Die()
//    {
//        isDead = true;
//        anim.SetBool("die", true); // Mainkan animasi mati
//        Destroy(gameObject,0.5f);
//    }

//    private void Flip()
//    {
//        isFacingRight = !isFacingRight;
//        Vector3 scale = transform.localScale;
//        scale.x *= -1;
//        transform.localScale = scale;
//    }
//}
