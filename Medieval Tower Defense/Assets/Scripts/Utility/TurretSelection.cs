using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretSelection : MonoBehaviour
{

    GameObject baseTower;
    Resources_Health R_H;
    AutomatedTest currentMouseValues = new AutomatedTest();
    public static Transform currentNode;
    public static GameObject currentTower;
    public static GameObject nextTower;
    int gameTicks = 0;

    private void Start()
    {
        baseTower = Resources.Load("MachineGun_Lvl1") as GameObject;
        R_H = Camera.main.GetComponent<Resources_Health>();
    }

    private void FixedUpdate()
    {
        gameTicks++;
    }

    public void SpawnMachineGunTurret()
    {
        if (baseTower.GetComponent<Towers>().TowerCost() <= R_H.GetResources())
        {
            MouseEvents thisMouseEvent = new MouseEvents(Input.mousePosition.x, Input.mousePosition.y, true, gameTicks);
            currentMouseValues.StoreMousePosition(thisMouseEvent);
            R_H.SetResources(-baseTower.GetComponent<Towers>().towerCost);
            Instantiate(baseTower, currentNode.position + new Vector3(0, 1, 0), Quaternion.identity, currentNode);
            currentNode.gameObject.GetComponent<Renderer>().enabled = false;
            currentNode.gameObject.GetComponent<BoxCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("TurretSpawnButton").SetActive(false);
        }
    }

    public void UpgradeMachineGunTurret()
    {
        if (nextTower.GetComponent<Towers>().TowerCost() <= R_H.GetResources())
        {
            MouseEvents thisMouseEvent = new MouseEvents(Input.mousePosition.x, Input.mousePosition.y, true, gameTicks);
            currentMouseValues.StoreMousePosition(thisMouseEvent);
            R_H.SetResources(-nextTower.GetComponent<Towers>().towerCost);
            Instantiate(nextTower, currentNode.position + new Vector3(0, 1, 0), Quaternion.identity, currentNode);
            Destroy(currentTower, .01f);
            GameObject.FindGameObjectWithTag("TurretUpgradeButton").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("TurretUpgradeButton").GetComponent<Button>().enabled = false;
        }
    }

    public int GetGameTicks()
    {
        return gameTicks;
    }
}
