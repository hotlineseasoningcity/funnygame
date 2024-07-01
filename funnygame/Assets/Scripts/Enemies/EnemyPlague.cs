using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlague : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay, initialSpawnDelay;
    public int maxEnemies;
    float timeSinceFirstSpawn = 0;

    public Health ehScript;

    void Start()
    {
        Invoke("SpawnEnemy", initialSpawnDelay);
    }

    void SpawnEnemy()
    {
        if (!ehScript.isDead)
        {
            Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, Random.value, 10f));
            spawnPosition.z = 0f;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

     void Update()
    {
        timeSinceFirstSpawn += Time.deltaTime;
        if (timeSinceFirstSpawn > 5f)
        {
            spawnDelay = Mathf.Max(spawnDelay * 0.5f, 0.5f);
        }
    }
}
