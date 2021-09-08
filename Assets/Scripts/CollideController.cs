using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideController : MonoBehaviour
{
    public bool thisWalkInside = false;
    public bool thisWalkOutside = false;
    public bool thisWalkInBush = false;
    public bool thisPowerOff = false;
    public bool inZonePowerOff = false;
    public bool power = true;
    public bool thisTryTalk = false;
    public bool thisWalkInBuilding = false;
    public bool thisSecondWalkInside = false;
    [Space(10)]
    public GameplayScript gameplayscript;
    public GameObject interactIcon;
    public bool interactOnlyExit = false;
    public bool interactOnlyEnter = false;
    public bool interactOnlyOneTime = false;
    public int countOfInteractTimes;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (interactOnlyOneTime)
        {
            if (countOfInteractTimes == 0)
            {
                if (interactIcon != null && interactOnlyExit == false)
                {
                    interactIcon.SetActive(true);
                    countOfInteractTimes++;
                }
            }
        }
        else
        {
            if (interactIcon != null && interactOnlyExit == false)
            {
                interactIcon.SetActive(true);
                countOfInteractTimes++;
            }
        }
        if (thisWalkInside)
        {
            gameplayscript.PlayerTryWalkInside();
        }
        if (thisWalkInBush)
        {
            gameplayscript.PlayerWalkInBush();
        }
        if (thisPowerOff)
        {
            inZonePowerOff = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (interactOnlyOneTime)
        {
            if (countOfInteractTimes > 0)
            {
                if (interactIcon != null && interactOnlyEnter == false)
                {
                    interactIcon.SetActive(!interactIcon.activeSelf);
                    countOfInteractTimes--;
                }
            }
        }
        else
        {
            if (interactIcon != null && interactOnlyEnter == false)
            {
                interactIcon.SetActive(!interactIcon.activeSelf);
                countOfInteractTimes++;
            }
        }
        if (thisWalkInside)
        {
            gameplayscript.PlayerWalkOutside();
        }
        if (thisPowerOff)
        {
            inZonePowerOff = false;
            interactIcon.SetActive(false);
        }
    }

    private void Update()
    {
        if (thisPowerOff && inZonePowerOff && Input.GetKeyDown(KeyCode.E))
        {
            gameplayscript.PlayerTurnPowerOff();
            power = false;
        }
    }
}
