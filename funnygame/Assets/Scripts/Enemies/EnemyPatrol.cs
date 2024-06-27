using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float spd;

    public Transform[] patrolPosArr;
    int patrolPosI;

    void Start()
    {
        transform.position = patrolPosArr[0].position;
    }

    void Patrol()
    {
        
    }
}
