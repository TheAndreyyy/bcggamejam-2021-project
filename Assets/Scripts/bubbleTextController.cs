using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleTextController : MonoBehaviour
{
    public float stayTime = 0;
    public float stayedTime = 0;
    public bool stayed = true;
    public bool show = false;
    public bool isLastbubble = false;
    public float activeTime = 0;
    public float nowTime = 0;
    public SpriteRenderer sprite;
    public GameObject activatedGO;

    void FixedUpdate()
    {
        if (stayTime > 0)
        {
            stayed = false;
            if (stayedTime < stayTime)
            {
                stayedTime += Time.fixedDeltaTime;
            }
            else
            {
                stayed = true;
            }
        }
        if (activeTime > 0 && stayed)
        {
            if (nowTime < activeTime)
            {
                nowTime += Time.fixedDeltaTime;
                show = true;
            }
            else
            {
                gameObject.SetActive(false);
                show = false;
            }
        }
        if (show)
        {
            sprite.enabled = true;
        }
        else
        {
            sprite.enabled = false;
        }
        if (isLastbubble && !show && nowTime>activeTime)
        {
            activatedGO.SetActive(true);
        }
    }
}
