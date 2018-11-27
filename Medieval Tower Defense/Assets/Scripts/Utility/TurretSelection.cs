using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretSelection : MonoBehaviour
{

    GameObject baseMachineGunTower;
    GameObject baseLaserTower;
    Resources_Health R_H;
    AutomatedTest currentMouseValues = new AutomatedTest();
    public static Transform currentNode;
    public static GameObject currentTower;
    public static GameObject nextTower;
    int gameTicks = 0;

    private void Start()
    {
        baseMachineGunTower = Resources.Load("MachineGun_Lvl1") as GameObject;
        baseLaserTower = Resources.Load("LaserTower_Lvl1") as GameObject;
        R_H = Camera.main.GetComponent<Resources_Health>();
    }

    private void FixedUpdate()
    {
        gameTicks++;
    }

    /// <summary>
    /// If there is enough resources to spawn a turret then spawn 
    /// one at current location of the node that is selected
    /// </summary>
    public void SpawnMachineGunTurret()
    {
        if (baseMachineGunTower.GetComponent<Towers>().TowerCost() <= R_H.GetResources())
        {
            MouseEvents thisMouseEvent = new MouseEvents(Input.mousePosition.x, Input.mousePosition.y, true, gameTicks);
            currentMouseValues.StoreMousePosition(thisMouseEvent);
            R_H.SetResources(-baseMachineGunTower.GetComponent<Towers>().towerCost);
            Instantiate(baseMachineGunTower, currentNode.position + new Vector3(0, 1, 0), Quaternion.identity, currentNode);
            currentNode.gameObject.GetComponent<Renderer>().enabled = false;
            currentNode.gameObject.GetComponent<BoxCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("TurretSpawnButton").SetActive(false);
            GameObject.FindGameObjectWithTag("LaserTowerSpawnButton").SetActive(false);
        }
    }

    /// <summary>
    /// If there is enough resources to spawn a turret then spawn 
    /// one at current location of the node that is selected
    /// </summary>
    public void SpawnLaserTurret()
    {
        if (baseLaserTower.GetComponent<Towers>().TowerCost() <= R_H.GetResources())
        {
            MouseEvents thisMouseEvent = new MouseEvents(Input.mousePosition.x, Input.mousePosition.y, true, gameTicks);
            currentMouseValues.StoreMousePosition(thisMouseEvent);
            R_H.SetResources(-baseLaserTower.GetComponent<Towers>().towerCost);
            Instantiate(baseLaserTower, currentNode.position + new Vector3(0, 0, 0), Quaternion.identity, currentNode);
            currentNode.gameObject.GetComponent<Renderer>().enabled = false;
            currentNode.gameObject.GetComponent<BoxCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("LaserTowerSpawnButton").SetActive(false);
            GameObject.FindGameObjectWithTag("TurretSpawnButton").SetActive(false);
        }
    }

    /// <summary>
    /// If the player has enough resources, replace the current tower with the next level.
    /// </summary>
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

    public void UpgradeLaserTurret()
    {
        if (nextTower.GetComponent<Towers>().TowerCost() <= R_H.GetResources())
        {
            MouseEvents thisMouseEvent = new MouseEvents(Input.mousePosition.x, Input.mousePosition.y, true, gameTicks);
            currentMouseValues.StoreMousePosition(thisMouseEvent);
            R_H.SetResources(-nextTower.GetComponent<Towers>().towerCost);
            Instantiate(nextTower, currentNode.position + new Vector3(0, 0, 0), Quaternion.identity, currentNode);
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
