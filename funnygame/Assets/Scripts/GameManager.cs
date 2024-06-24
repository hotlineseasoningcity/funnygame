using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float timer, currentTimeTimer;
    public float probSpawnEnemies;


    public GameObject prefabEnemy;
    public Transform spawnerEnemies;

    //enemies

    public float spdEnemies;

    public void SpawnEnemies()
    {
        probSpawnEnemies = Random.value;
        currentTimeTimer += Time.deltaTime;
        if (currentTimeTimer >= timer)
        {
            if (probSpawnEnemies <= 0.5)
            {
                GameObject newEnemy = Instantiate(prefabEnemy, spawnerEnemies.position, spawnerEnemies.rotation);
                Destroy(newEnemy, 1);
                currentTimeTimer = 0;
            }
        }
    }

    void Update()
    {
        SpawnEnemies();
    }
}
