using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeSpawner : MonoBehaviour
{
    GameObject baseTower;
    Resources_Health R_H;

    private void Start()
    {
        baseTower = Resources.Load("MachineGun_Lvl1") as GameObject;
        R_H = Camera.main.GetComponent<Resources_Health>();
    }

    private void OnMouseDown()
    {
        if (baseTower.GetComponent<Towers>().TowerCost() <= R_H.GetResources())
        {
            R_H.SetResources(-baseTower.GetComponent<Towers>().towerCost);
            Instantiate(baseTower, this.transform.position + new Vector3(0, 1, 0), this.transform.rotation);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
