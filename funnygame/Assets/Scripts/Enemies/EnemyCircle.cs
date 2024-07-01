using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircle : MonoBehaviour
{
    public float circleDis, circleSpd, angle;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void CirclePlayer()
    {
        float dis = Vector3.Distance(transform.position, player.position);

        if (dis <= circleDis * 2)
        {
            angle += Time.deltaTime * circleSpd;

            float x = Mathf.Cos(angle) * circleDis + player.position.x;
            float y = Mathf.Sin(angle) * circleDis + player.position.y;
            transform.position = new Vector3(x, y, transform.position.z);

            transform.rotation = Quaternion.LookRotation(Vector3.forward, player.position - transform.position);
        }
    }

    void Update()
    {
        CirclePlayer();
    }
}
