using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int dmg;
     private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") || col.CompareTag("Boss"))
        {
            Health hp = col.GetComponent<Health>();
            BossController bossHp = col.GetComponent<BossController>();

            if (hp != null)
            {
                hp.TakeDamage(dmg);
            }
            if (bossHp != null)
            {
                bossHp.TakeDamage(dmg);
            }
        }
    }
}
