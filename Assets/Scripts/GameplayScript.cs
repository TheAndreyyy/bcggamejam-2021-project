using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayScript : MonoBehaviour
{
    public bool playerTryWalkInside = false;
    public bool playerWalkOutside = false;
    public bool playerWalkInBush = false;
    public bool powerIsOff = false;
    public bool liftIsOn = false;
    public GameObject buildingPowerIsOn;
    public GameObject buildingPowerIsOff;
    public GameObject player;
    public GameObject playerSpawnPoint;
    public doorController door1;
    public GameObject switchedPower;
    public GameObject playerBubble2;
    public GameObject switchedFence;
    public List<enemyMoveController> enemiesList;
    public doorController bottomDoor;
    public Animator animatorDeath;

    private void Start()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemiesList.Add(item.GetComponent<enemyMoveController>());
        }
    }

    public void PlayerTryWalkInside()
    {
        if (playerTryWalkInside == false)
        {
            playerTryWalkInside = true;
        }
    }

    public void PlayerWalkOutside()
    {
        if (playerTryWalkInside && playerWalkOutside == false)
        {
            playerWalkOutside = true;
            door1.canOpened = false;
            playerBubble2.SetActive(true);
        }
    }

    public void PlayerWalkInBush()
    {
        if (playerWalkOutside == true && playerWalkInBush == false)
        {
            playerWalkInBush = true;
            player.transform.position = playerSpawnPoint.transform.position;
        }
    }

    public void PlayerTurnPowerOff()
    {
        bottomDoor.canOpened = true;
        buildingPowerIsOn.SetActive(false);
        buildingPowerIsOff.SetActive(true);
        powerIsOff = true;
        switchedPower.SetActive(false);
        switchedFence.SetActive(false);
        AllEnemiesTurnOnFlashlights();
    }

    public void AllEnemiesTurnOnFlashlights()
    {
        foreach (var item in enemiesList)
        {
            item.flashlight.SetActive(true);
        }
    }

    public void Death()
    {
        animatorDeath.SetBool("isDead", true);
        
        //Time.timeScale = 0;
        //Debug.LogError("game over");
        //SceneManager.LoadScene("FinishScene");
        //Time.timeScale = 0f;
    }
}
