using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideController : MonoBehaviour
{
    public GameObject interactButton;
    public bool inZone = false;
    public bool inHide = false;
    public GameplayScript gameplayscript;
    public GameObject player;
    public GameObject playerSpawner;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inHide == false)
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inHide == false && inZone)
            {
                //anim.Play("idle");
                player.GetComponent<SpriteRenderer>().enabled = false;
                player.GetComponent<CapsuleCollider2D>().enabled = false;
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                inHide = true;
                player.transform.position = playerSpawner.transform.position;
                animator.SetBool("isHide", true);
            }
            else
            {
                if (inHide == true && inZone == false)
                {
                    player.GetComponent<SpriteRenderer>().enabled = true;
                    player.GetComponent<CapsuleCollider2D>().enabled = true;
                    player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                    player.transform.position = playerSpawner.transform.position;
                    inHide = false;
                    animator.SetBool("isHide", false);
                }
            }
        }
    }
}
