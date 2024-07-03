using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float spd, maxDisFromStart;
    Vector3 startPos;

    Rigidbody2D rb;

    void Start()
    {
        startPos = transform.position;
    }

    void Move()
    {
        float y = startPos.y + Mathf.Sin(Time.time * spd) * maxDisFromStart;
        float x = startPos.x + Mathf.Cos(Time.time * spd) * maxDisFromStart;        
        transform.position = new Vector3(x, y, transform.position.z);
    }

    void Update()
    {
        Move();
    }
}
