using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int playerScore = 0;
    public TextMeshProUGUI points;

    public List<GameObject> enemyPrefabs;
    public Transform[] spawnPoints, spawnPointsEnemy1, spawnPointsEnemy5;

    public GameObject bossPrefab;
    public Transform spawnPointBoss;

    float timer, spawnInterval = 3f, nextSpawnTime;
    public int enemiesOnScreen = 0, maxEnemies = 8;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (enemiesOnScreen < maxEnemies)
            {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        int randomI = Random.Range(0, spawnPoints.Length);
        int randomIEnemy1 = Random.Range(0, spawnPointsEnemy1.Length);
        int randomIEnemy5 = Random.Range(0, spawnPointsEnemy5.Length);

        Transform spawnPoint = spawnPoints[randomI];
        Transform spawnPointEnemy1 = spawnPointsEnemy1[randomIEnemy1];
        Transform spawnPointEnemy5 = spawnPointsEnemy5[randomIEnemy5];

        if (timer < 60)
        {
            // spawn enemy type 1
            Instantiate(enemyPrefabs[0], spawnPointEnemy1.position, spawnPointEnemy1.rotation);
        }
        else if (timer >= 60 && timer < 120)
        {
            // spawn enemy type 1 & 2
            Instantiate(enemyPrefabs[0], spawnPointEnemy1.position, spawnPointEnemy1.rotation);
            Instantiate(enemyPrefabs[1], spawnPoint.position, spawnPoint.rotation);
        }
        else if (timer >= 120 && timer < 180)
        {
            // spawn enemy type 1 2 & 3
            Instantiate(enemyPrefabs[0], spawnPointEnemy1.position, spawnPointEnemy1.rotation);
            Instantiate(enemyPrefabs[1], spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefabs[2], spawnPoint.position, spawnPoint.rotation);
        }
        else if (timer >= 180 && timer < 240)
        {
            // spawn enemy type 1 2 3 & 4
            Instantiate(enemyPrefabs[0], spawnPointEnemy1.position, spawnPointEnemy1.rotation);
            Instantiate(enemyPrefabs[1], spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefabs[2], spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefabs[3], spawnPoint.position, spawnPoint.rotation);
        }

        else if (timer >= 300)
        {
            // spawn boss
            DestroyAllEnemies();
            Instantiate(bossPrefab, spawnPointBoss.position, spawnPointBoss.rotation);
        }

        if (Random.Range(0, 100) < 10)
        {
            // spawn enemy type 5 randomly except when boss
            Instantiate(enemyPrefabs[4], spawnPointEnemy5.position, spawnPointEnemy5.rotation);
        }
        
        enemiesOnScreen++;
        nextSpawnTime = Time.time + spawnInterval;
    }

    public void IncreaseScore(int amount)
    {
        playerScore += amount;
        points.text = "POINTS = " + playerScore;
    }

    public void EnemyDestroyed()
    {
        enemiesOnScreen--;
    }

    void DestroyAllEnemies()
{
    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
    foreach (GameObject enemy in enemies)
    {
        gameObject.SetActive(false);
    }
}

    void Update()
    {
        timer += Time.deltaTime;
    }
}