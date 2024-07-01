using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCollect : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI gold;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Coin"))
        {
            coins++;
            gold.text = "GOLD = " + coins;
        }
    }
}
