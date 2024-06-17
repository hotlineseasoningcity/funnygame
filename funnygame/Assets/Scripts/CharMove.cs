using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    public float movSpd, rotateSpd;
    float horizontal, vertical;

    Rigidbody2D rb;
    SpriteRenderer sr;
   
    void Start()
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
        rb.velocity = new Vector2(horizontal, vertical).normalized * movSpd;
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.forward, rotateSpd * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.forward, -rotateSpd * Time.deltaTime);
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
