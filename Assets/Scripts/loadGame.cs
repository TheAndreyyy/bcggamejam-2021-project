using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadGame : MonoBehaviour
{
    public Animator animator;
    public void loadLevel(string str)
    {
        SceneManager.LoadScene(str);
    }

    public void playAnim()
    {
        animator.Play("");
    }
}
