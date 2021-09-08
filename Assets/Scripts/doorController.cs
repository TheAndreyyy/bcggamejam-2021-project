using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public GameObject door;
    public bool canOpened = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canOpened)
        {
            door.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        door.SetActive(true);
    }

}
