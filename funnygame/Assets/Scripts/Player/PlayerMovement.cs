using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpd;
    float horizontal, vertical;

    Rigidbody2D rb;
    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
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
            sr.flipX = true;
        }
        if (horizontal > 0)
        {
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
