using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public PlayerManager pmScript;

    void Update()
    {
        if (pmScript.isDead)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
