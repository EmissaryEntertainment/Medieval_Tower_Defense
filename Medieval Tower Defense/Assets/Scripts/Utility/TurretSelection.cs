using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSelection : MonoBehaviour
{

    GameObject baseTower;
    Resources_Health R_H;
    AutomatedTest currentMouseValues = new AutomatedTest();
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
            Instantiate(baseTower, this.transform.parent.transform.position + new Vector3(0, 1, 0), this.transform.rotation,this.transform);
            transform.parent.gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public int GetGameTicks()
    {
        return gameTicks;
    }
}
