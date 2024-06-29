using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpd;
    float horizontal, vertical;

    public bool isFacingRight;

    Rigidbody2D rb;
    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        isFacingRight = true;
    }

    void GetPlayerInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {
        rb.velocity = new Vector2(horizontal, vertical).normalized * moveSpd;
        if (horizontal < 0)
        {
            isFacingRight = false;
            sr.flipX = true;
        }
        if (horizontal > 0)
        {
            isFacingRight = true;
            sr.flipX = false;
        }
    }

    void Update()
    {
        GetPlayerInput();
    }

    void FixedUpdate()
    {
        Move();
    }
}
