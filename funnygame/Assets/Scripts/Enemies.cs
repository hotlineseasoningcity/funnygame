using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float spd;
    public GameObject[] pointsArr;
    Transform currentPoint;

    
    Rigidbody2D rb;
    SpriteRenderer sr;

    public GameManager gm;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        currentPoint = pointsArr[1].transform;
    }

    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointsArr[1].transform)
        {
            rb.velocity = new Vector2(spd, 0);
        }
        else
        {
            rb.velocity = new Vector2(-spd, 0);
        }
    }
}
