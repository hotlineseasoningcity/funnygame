using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpd;
    public float verticalOffset;
    public Transform player;

    void Follow()
    {
        Vector3 newPos = new Vector3(player.position.x, player.position.y + verticalOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpd * Time.deltaTime);
    }

    void Update()
    {
        Follow();
    }
}
