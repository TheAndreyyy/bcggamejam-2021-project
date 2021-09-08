using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animScript : MonoBehaviour
{
    public Animator animator;
    public GameplayScript gameplayscript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void animEnd()
    {
        animator.SetBool("levelIsLoaded",true);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene("FinishScene");
    }

    public void endGame() {
        Application.Quit();
    }
}
