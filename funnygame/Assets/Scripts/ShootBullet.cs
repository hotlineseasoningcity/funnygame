using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public float bulletSpd, bulletLifetime;

    public GameObject prefabBullet;
    public Transform spawnerBullet;

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject newBullet = Instantiate(prefabBullet, spawnerBullet.position, spawnerBullet.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10, ForceMode2D.Impulse);
            Destroy(newBullet, bulletLifetime);
        }
    }

    void Update()
    {
        Shoot();
    }
}
