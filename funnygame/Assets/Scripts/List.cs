using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{
    public GameObject enemyPref;
    public List<Enemies> enemyList;

    void AddEnemy()
    {
        _ = Instantiate(enemyPref);
        Enemies enemy = GetComponent<Enemies>();
        enemyList.Add(enemy);
    }
    
    void SpawnEnemy(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            AddEnemy();
        }
    }
}
