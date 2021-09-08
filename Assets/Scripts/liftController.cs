using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftController : MonoBehaviour
{
    public GameObject interactButton;
    public GameObject destinationPoint;
    public bool inZone = false;
    public bool this3Lift = false;
    public GameObject player;
    public GameplayScript gameplayscript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this3Lift)
        {
            if (gameplayscript.liftIsOn)
            {
                interactButton.SetActive(true);
                inZone = true;
            }
        }
        else
        {
            interactButton.SetActive(true);
            inZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactButton.SetActive(false);
        inZone = false;
    }

    private void Update()
    {
        if (inZone && Input.GetKeyDown(KeyCode.E))
        {
            if (this3Lift)
            {
                if (gameplayscript.liftIsOn)
                {
                    player.transform.position = destinationPoint.transform.position;
                }
            }
            else
            {
                player.transform.position = destinationPoint.transform.position;
            }
        }
    }
}
