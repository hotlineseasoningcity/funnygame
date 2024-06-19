using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float baseSpd;

    public GameManager gm;
    public Vector3 dir;

    private void Update()
    {
        transform.position += baseSpd * gm.spdEnemies * Time.deltaTime * dir;
    }
}
