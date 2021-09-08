using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    public GameplayScript gameplayScript;
    public GameObject childGroupForText;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (horizontalMove == 0)
        {
            animator.SetBool("isRun", false);
        }
        else
        {
            animator.SetBool("isRun", true);
        }
        if (jump == true)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "flashlight" || collision.gameObject.tag == "fence")
        {
            gameplayScript.Death();
            //Debug.LogError("game over");
            //SceneManager.LoadScene("FinishScene");
            //Time.timeScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    private void FixedUpdate()
    {
        //if (GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
        //{
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
        //}
    }
}
