using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchController : MonoBehaviour
{
    public GameObject interactButton;
    public GameObject switcherOff;
    public GameplayScript gameplayscript;
    public GameObject lampOff;
    public SpriteRenderer lampOn;
    public bool inZone = false;
    public bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated == false)
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
        if (inZone && activated == false && Input.GetKeyDown(KeyCode.E))
        {
            activated = true;
            gameplayscript.liftIsOn = true;
            switcherOff.SetActive(false);
            lampOff.SetActive(false);
            lampOn.enabled = true;
        }
    }
}
