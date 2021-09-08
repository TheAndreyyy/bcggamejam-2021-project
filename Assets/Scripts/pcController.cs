using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcController : MonoBehaviour
{
    public GameObject interactButton;
    public bool inZone = false;
    public bool activated = false;
    public GameObject text;

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
        if (inZone && Input.GetKeyDown(KeyCode.E))
        {
            text.SetActive(true);
        }
    }

    public void onText()
    {
        text.SetActive(true);
    }
}
