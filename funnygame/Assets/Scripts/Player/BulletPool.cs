using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;

    public GameObject bulletPref;
    public int bulletsToPreInstantiate;

    public List<GameObject> pooledBullets;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pooledBullets = new List<GameObject>();
        for (int i = 0; i < bulletsToPreInstantiate; i++)
        {
            GameObject obj = Instantiate(bulletPref);
            obj.SetActive(false);
            pooledBullets.Add(obj);
        }
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < pooledBullets.Count; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                pooledBullets[i].SetActive(true);
                return pooledBullets[i];
            }
        }

        GameObject obj = Instantiate(bulletPref);
        pooledBullets.Add(obj);
        return obj;
    }

    public void ReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
