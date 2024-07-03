using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int dmg;
    Health phScript;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        phScript = player.GetComponent<Health>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            phScript.TakeDamage(dmg);
        }
    }
}
