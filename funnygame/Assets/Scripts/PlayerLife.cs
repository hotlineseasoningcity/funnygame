using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public float dmgPlayer;

    public float life;
    public float currentDmg;

    public Enemies enemiesScript;

    public bool isDead;

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
