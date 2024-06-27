using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Health phScript;

    void Update()
    {
        if (phScript.isDead)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
