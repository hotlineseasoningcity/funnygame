using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeBar : MonoBehaviour
{
    public Health phScript;
    public Image hpFiller;
    float targetFillAmount, elapsedTime, lerpDuration = 0.5f;
    
    void UpdateHealthBar()
    {
        if (phScript.hp == 8)
        {
            targetFillAmount = 1;
        }
        if (phScript.hp == 7)
        {
            targetFillAmount = 0.85f;
        }
        else if (phScript.hp == 6)
        {
            targetFillAmount = 0.75f;
        }
        else if (phScript.hp == 5)
        {
            targetFillAmount = 0.65f;
        }
        else if (phScript.hp == 4)
        {
            targetFillAmount = 0.5f;
        }
        else if (phScript.hp == 3)
        {
            targetFillAmount = 0.4f;
        }
        else if (phScript.hp == 2)
        {
            targetFillAmount = 0.25f;
        }
        else if (phScript.hp == 1)
        {
            targetFillAmount = 0.15f;
        }
        else if (phScript.hp == 0)
        {
        targetFillAmount = 0;
        }
        
        elapsedTime += Time.deltaTime;
        hpFiller.fillAmount = Mathf.Lerp(hpFiller.fillAmount, targetFillAmount, elapsedTime / lerpDuration);
        if (elapsedTime >= lerpDuration)
        {
            elapsedTime = 0;
        }
    }

    void Update()
    {
        UpdateHealthBar();
    }
}
