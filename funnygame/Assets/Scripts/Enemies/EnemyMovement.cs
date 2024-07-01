using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float spd, maxDisFromStart;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void MoveEnemy()
    {
        float y = startPos.y + Mathf.Sin(Time.time * spd) * maxDisFromStart;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    void Update()
    {
        MoveEnemy();
    }
}
