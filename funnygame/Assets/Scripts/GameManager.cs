using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float timer, currentTimeTimer;
    public float probSpawnEnemies;


    public GameObject[] prefabEnemies;
    public Transform spawnerEnemies;

    //enemies

    public float spdEnemies;
    public Vector3 dirEnemies = new(0, 5, 0);

    public void SpawnEnemies()
    {
        probSpawnEnemies = Random.value;
        currentTimeTimer += Time.deltaTime;
        if (currentTimeTimer >= timer)
        {
            if (probSpawnEnemies <= 0.2)
            {
                GameObject newEnemy = Instantiate(prefabEnemies[Random.Range(1, prefabEnemies.Length)], spawnerEnemies.position, spawnerEnemies.rotation);
                newEnemy.GetComponent<Enemies>().gm = this;
                newEnemy.GetComponent<Enemies>().dir = dirEnemies;
                newEnemy.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                Destroy(newEnemy, 2);
                currentTimeTimer = 0;
            }
        }
    }

    void Update()
    {
        SpawnEnemies();
    }
}
