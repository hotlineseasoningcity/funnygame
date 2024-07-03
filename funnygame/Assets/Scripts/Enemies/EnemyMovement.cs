using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float spd, maxDisFromStart, delay;
    Vector3 startPos;

    float RandomDelay()
    {
        float minDelay = 0.5f, maxDelay = 2.0f;
        return Random.Range(minDelay, maxDelay);

    }

    void Start()
    {
        startPos = transform.position;
        delay = RandomDelay();
    }

    void MoveEnemy()
    {
        float y = startPos.y + Mathf.Sin((Time.time + delay) * spd) * maxDisFromStart;        
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    void Update()
    {
        MoveEnemy();
    }
}
