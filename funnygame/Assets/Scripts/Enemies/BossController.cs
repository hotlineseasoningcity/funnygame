using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public int maxHp = 100, hp;
    private bool isBossDead = false;

    void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0 && !isBossDead)
        {
            isBossDead = true;
            StartCoroutine(DelayedVictory());
        }
    }

    IEnumerator DelayedVictory()
    {
        yield return new WaitForSeconds(5f);
        LoadVictoryScene();
    }

    void LoadVictoryScene()
    {
        SceneManager.LoadScene("Victory");
    }
}