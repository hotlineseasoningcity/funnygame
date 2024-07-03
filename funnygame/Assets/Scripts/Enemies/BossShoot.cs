using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnBullet;
    public float bulletSpd, shootingRate, lastShotTime;

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnBullet.position, spawnBullet.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = spawnBullet.right * bulletSpd;
    }

    void Update()
    {
        if (Time.time > lastShotTime + shootingRate)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }
}
