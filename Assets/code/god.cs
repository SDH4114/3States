using UnityEngine;

public class god : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float ascendSpeed = 3f;
    public float maxSpeed = 10f;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private CircleCollider2D coll;
    public static int health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        coll = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        Move();
        Ascend();
        Flip();
        ToggleCollider();
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
    }

    void Ascend()
    {
        float ascend = Input.GetAxis("Vertical");
        Vector2 newVelocity = new Vector2(rb.velocity.x, ascend * ascendSpeed);
        rb.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
    }

    void Flip()
    {
        if ((rb.velocity.x > 0 && !facingRight) || (rb.velocity.x < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void ToggleCollider()
    {
        if (Input.GetKeyDown(KeyCode.L) && coll != null)
        {
            coll.enabled = !coll.enabled;
        }
    }
}