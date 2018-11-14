using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NodeSpawner : MonoBehaviour
{
    GameObject turretSpawnButton;

    GameObject[] allNodes;

    AutomatedTest currentMouseValues = new AutomatedTest();

    public Material selectedNodeMat;
    public Material unselectedNodeMat;

    private int gameTicks = 0;

    private void Awake()
    {
        turretSpawnButton = GameObject.FindGameObjectWithTag("TurretSpawnButton");
    }

    private void Start()
    {
        for (int i = 0; i < 70; i++)
        {
            allNodes = GameObject.FindGameObjectsWithTag("Node");
        }
        turretSpawnButton.SetActive(false);
    }

    private void FixedUpdate()
    {
        gameTicks++;
    }

    private void OnMouseDown()
    {
        if (GameObject.FindGameObjectWithTag("TurretUpgradeButton").GetComponent<Image>().enabled == true)
        {
            GameObject.FindGameObjectWithTag("TurretUpgradeButton").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("TurretUpgradeButton").GetComponent<Button>().enabled = false;
        }
        for (int i = 0;i<allNodes.Length;i++)
        {
            allNodes[i].GetComponent<Renderer>().material = unselectedNodeMat;
        }
        this.GetComponent<Renderer>().material = selectedNodeMat;
        turretSpawnButton.SetActive(true);
        TurretSelection.currentNode = this.transform;
        MouseEvents thisMouseEvent = new MouseEvents(Input.mousePosition.x,Input.mousePosition.y, true, gameTicks);
        currentMouseValues.StoreMousePosition(thisMouseEvent);
    }
}
