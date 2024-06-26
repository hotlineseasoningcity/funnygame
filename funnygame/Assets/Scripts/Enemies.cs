using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float life, dmg, currentDmg;
    public bool isDead;

    public PlayerManager pmScript;

    void TakeDmg(float dmg)
    {
        currentDmg += dmg;
        if (currentDmg >= life)
        {
            isDead = true;
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            TakeDmg(pmScript.dmg);
        }
    }
}
