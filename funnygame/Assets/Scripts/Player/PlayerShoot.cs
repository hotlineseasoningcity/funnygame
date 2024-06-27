using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float bulletSpd, bulletLifetime;
    public Transform shootingPoint;

    IEnumerator DeactivateBulletCoroutine(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletLifetime);
        BulletPool.instance.ReturnBulletToPool(bullet);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullet = BulletPool.instance.GetBullet();
            bullet.transform.position = shootingPoint.position;
            bullet.transform.rotation = shootingPoint.rotation;

            bullet.GetComponent<Rigidbody2D>().velocity = shootingPoint.right * bulletSpd;

            StartCoroutine(DeactivateBulletCoroutine(bullet));
        }
    }
    
    void Update()
    {
        Shoot();
    }
}
