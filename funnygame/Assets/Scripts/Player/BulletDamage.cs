using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int dmg;
     private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Health hp = col.GetComponent<Health>();

            if (hp != null)
            {
                hp.TakeDamage(dmg);
            }
        }
    }

}
