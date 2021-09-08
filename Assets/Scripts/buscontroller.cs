using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buscontroller : MonoBehaviour
{
    public bool inZone = false;
    public loadGame door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inZone = true;

    }

    private void Update()
    {
        if (inZone)
        {
            door.loadLevel("FinishScene");
        }
    }
}
