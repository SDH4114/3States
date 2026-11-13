using UnityEngine;

public class contWater : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public GameObject groundCheckObject; 
    public float groundCheckRadius = 0.3f;

    private Rigidbody2D rb;
    private Transform groundCheck;
    private bool isGrounded = true;
    private bool canDoubleJump;
    private bool facingRight = true;

    [SerializeField] private int healthInspector;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D не найден!");
        }

        if (groundCheckObject != null)
        {
            groundCheck = groundCheckObject.transform;
        }
        else
        {
            Debug.LogError("Объект groundCheckObject не назначен!");
        }

    }

    void Update()
    {
        Move();
        Jump();
        Flip();
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        if (rb != null)
        {
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
        }
    }

    void Jump()
    {
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        if (isGrounded)
        {
            canDoubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded) 
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (canDoubleJump) 
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                canDoubleJump = false;
            }
        }
    }

    void Flip()
    {
        float move = Input.GetAxis("Horizontal");

        if ((move > 0 && !facingRight) || (move < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}