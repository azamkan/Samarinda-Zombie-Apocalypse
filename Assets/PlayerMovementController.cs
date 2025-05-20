using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float acceleration = 15f;
    [SerializeField] private float deceleration = 15f;

    [Header("Rigidbody Settings")]
    [SerializeField] private float linearDrag = 4f;
    [SerializeField] private float gravityScale = 3f;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isFacingRight = true;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = linearDrag;
        rb.gravityScale = gravityScale;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        anim.SetBool("run", moveInput != 0);

        // Flip handling
        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        float targetSpeed = moveInput * moveSpeed;
        float speedDif = targetSpeed - rb.linearVelocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;
        float movement = speedDif * accelRate;

        rb.AddForce(Vector2.right * movement, ForceMode2D.Force);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
