using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contIce : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private bool facingRight = true;
    public static int health;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Flip();
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }
    void Flip()
    {
        if (rb.velocity.x > 0 && !facingRight || rb.velocity.x < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
