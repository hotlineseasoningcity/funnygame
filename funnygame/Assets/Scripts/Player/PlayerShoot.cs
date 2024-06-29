using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float bulletSpd, bulletLifetime;
    public Transform shootingPoint, shootingPoint2;
    public PlayerMovement pmScript;

    IEnumerator DeactivateBulletCoroutine(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletLifetime);
        BulletPool.instance.ReturnBulletToPool(bullet);
    }

    void Instantiator()
    {
        GameObject bullet = BulletPool.instance.GetBullet();
        if (pmScript.isFacingRight)
        {
            bullet.transform.position = shootingPoint.position;
            bullet.transform.rotation = shootingPoint.rotation;
            bullet.GetComponent<Rigidbody2D>().velocity = shootingPoint.right * bulletSpd;
        }
        else
        {
            bullet.transform.position = shootingPoint2.position;
            bullet.transform.rotation = shootingPoint2.rotation;
            bullet.GetComponent<Rigidbody2D>().velocity = shootingPoint2.right * bulletSpd;
        }
        StartCoroutine(DeactivateBulletCoroutine(bullet));
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiator();
        }
    }
    
    void Update()
    {
        Shoot();
    }
}
