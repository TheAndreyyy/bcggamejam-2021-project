using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowController : MonoBehaviour
{
    public GameObject interactButton;
    public bool inZone = false;
    public bool activated = false;
    public loadGame door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated == false)
        {
            if (interactButton != null)
            {
                interactButton.SetActive(true);
            }
            inZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (interactButton != null)
        {
            interactButton.SetActive(false);
        }
        inZone = false;
    }

    private void Update()
    {
        if (inZone && Input.GetKeyDown(KeyCode.E))
        {
            door.loadLevel("Bus");
        }
    }
}
