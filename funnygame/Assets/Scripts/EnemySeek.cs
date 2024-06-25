using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeek : MonoBehaviour
{
    public float seekSpd, rotationModifier;
    public float timer, interval;

    public GameObject pointA, pointB, blast;
    public Transform player;

    public SpriteRenderer sr;
    public Color enableBlastColor;
    public Color disableBlastColor;

    public bool isSeeking, isBlastActive, isOnPlayerRange = false;

    void Seek()
    {
        if (isSeeking)
        {
            Vector3 dir = pointA.transform.position - transform.position;
            float angle1 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - rotationModifier;
            
            dir = pointB.transform.position - transform.position;
            float angle2 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - rotationModifier;
            
            float t = Mathf.PingPong(Time.time / seekSpd, 1f);
            Quaternion targetRotation = Quaternion.Lerp(Quaternion.AngleAxis(angle1, Vector3.forward), Quaternion.AngleAxis(angle2, Vector3.forward), t);
            
            transform.rotation = targetRotation;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player.gameObject)
        {
            isOnPlayerRange = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player.gameObject)
        {
            isOnPlayerRange = false;
        }
    }

    void BlastPlayer()
    {
        sr.color = disableBlastColor;
        
        if (isOnPlayerRange)
        {
            isSeeking = false;
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                sr.color = enableBlastColor;
            }
        }
        else 
        {
            isSeeking = true;
            timer = 0;
        }
    }

    void Update()
    {
        BlastPlayer();
        Seek();
    }
}
