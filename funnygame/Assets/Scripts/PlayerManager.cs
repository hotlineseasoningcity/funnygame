using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float life, dmg, currentDmg;
    public bool isDead;

    public Enemies enemiesScript;

    void TakeDmg(float dmg)
    {
        currentDmg += dmg;
        if (currentDmg >= life)
        {
            isDead = true;
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            TakeDmg(enemiesScript.dmg);
        }
    }
}
