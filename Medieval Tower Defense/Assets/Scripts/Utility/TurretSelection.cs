using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSelection : MonoBehaviour
{

    GameObject baseTower;
    Resources_Health R_H;

    private void Start()
    {
        baseTower = Resources.Load("MachineGun_Lvl1") as GameObject;
        R_H = Camera.main.GetComponent<Resources_Health>();
    }

    public void SpawnMachineGunTurret()
    {
        if (baseTower.GetComponent<Towers>().TowerCost() <= R_H.GetResources())
        {
            R_H.SetResources(-baseTower.GetComponent<Towers>().towerCost);
            Instantiate(baseTower, this.transform.parent.transform.position + new Vector3(0, 1, 0), this.transform.rotation);
            transform.parent.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.SetActive(false);
        }
    }
}
