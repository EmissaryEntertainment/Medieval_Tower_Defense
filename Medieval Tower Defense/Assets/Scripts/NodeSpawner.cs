using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeSpawner : MonoBehaviour
{
    GameObject thisCanvas; // the child canvas of this object, used to instantiate turrets on button press.

    private float canvasTimer = 0; // used to diable canvas if the player has not utilized it within a set amount of time (10 second)

    AutomatedTest currentMouseValues = new AutomatedTest();

    private int gameTicks = 0;

    private void Start()
    {
        thisCanvas = transform.GetChild(0).transform.GetChild(0).gameObject;
        thisCanvas.SetActive(false);
    }

    private void FixedUpdate()
    {
        gameTicks++;
        if (thisCanvas.activeInHierarchy == true)
        {
            canvasTimer += Time.deltaTime;
        }
        else
        {
            canvasTimer = 0;
        }

        if(canvasTimer >= 10)
        {
            thisCanvas.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        thisCanvas.SetActive(true);
        MouseEvents thisMouseEvent = new MouseEvents(Input.mousePosition.x,Input.mousePosition.y, true, gameTicks);
        currentMouseValues.StoreMousePosition(thisMouseEvent);
    }
}
