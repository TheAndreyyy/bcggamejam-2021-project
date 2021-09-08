using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endOfGame : MonoBehaviour
{
    public GameObject interactButton;
    public bool inZone = false;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactButton.SetActive(true);
        inZone = true;
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
            animator.SetBool("EndOfGame", true);
        }
    }
}
