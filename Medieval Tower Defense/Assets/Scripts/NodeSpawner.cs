using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NodeSpawner : MonoBehaviour
{
    GameObject machineGunTurretSpawnButton;
    GameObject laserTurretSpawnButton;

    GameObject[] allNodes;

    AutomatedTest currentMouseValues = new AutomatedTest();

    public Material selectedNodeMat;
    public Material unselectedNodeMat;

    private int gameTicks = 0;

    private void Awake()
    {
        machineGunTurretSpawnButton = GameObject.FindGameObjectWithTag("TurretSpawnButton");
        laserTurretSpawnButton = GameObject.FindGameObjectWithTag("LaserTowerSpawnButton");
    }

    private void Start()
    {
        for (int i = 0; i < 70; i++)
        {
            allNodes = GameObject.FindGameObjectsWithTag("Node");
        }
        machineGunTurretSpawnButton.SetActive(false);
    }

    private void FixedUpdate()
    {
        gameTicks++;
    }

    private void OnMouseDown()
    {
        if (GameObject.FindGameObjectWithTag("TurretUpgradeButton").GetComponent<Image>().enabled == true && GameObject.FindGameObjectWithTag("LaserTowerSpawnButton").GetComponent<Image>().enabled)
        {
            GameObject.FindGameObjectWithTag("TurretUpgradeButton").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("TurretUpgradeButton").GetComponent<Button>().enabled = false;
            GameObject.FindGameObjectWithTag("LaserTowerSpawnButton").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("LaserTowerSpawnButton").GetComponent<Button>().enabled = false;
        }
        for (int i = 0;i<allNodes.Length;i++)
        {
            allNodes[i].GetComponent<Renderer>().material = unselectedNodeMat;
        }
        this.GetComponent<Renderer>().material = selectedNodeMat;
        machineGunTurretSpawnButton.SetActive(true);
        laserTurretSpawnButton.SetActive(true);
        TurretSelection.currentNode = this.transform;
        MouseEvents thisMouseEvent = new MouseEvents(Input.mousePosition.x,Input.mousePosition.y, true, gameTicks);
        currentMouseValues.StoreMousePosition(thisMouseEvent);
    }
}
