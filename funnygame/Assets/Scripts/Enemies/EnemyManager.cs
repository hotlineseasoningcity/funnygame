using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int minCoinsDropped, maxCoinsDropped;
    public GameObject coinPrefab;
    public Health hpScript;

    void DropCoin()
    {
        Vector3 randomOffset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f);
        Instantiate(coinPrefab, transform.position + randomOffset, transform.rotation);
    }

    void OnEnemyDeath()
    {
        int coinsToDrop = Random.Range(minCoinsDropped, maxCoinsDropped + 1);

        if (hpScript.isDead)
        {
            gameObject.SetActive(false);
            for (int i = 0; i < coinsToDrop; i++)
            {
                DropCoin();
            }
        }
    }

    void Update()
    {
        OnEnemyDeath();
    }
}
