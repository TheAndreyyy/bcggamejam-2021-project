using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poweredFence : MonoBehaviour
{
    public GameplayScript gameplayscript;
    void Update()
    {
        //if (gameplayscript.powerIsOff == false)
        //{
        //    GetComponent<SpriteRenderer>().color = Color.blue;
        //}
        //else
        //{
        //    GetComponent<SpriteRenderer>().color = Color.white;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (gameplayscript.powerIsOff == false)
        //{
        //    if (collision.gameObject.name == "Player")
        //    {
        //        Debug.LogError("game over");
        //    }
        //}
    }
}
