using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineGunTurretSpawnButtonControls : MonoBehaviour
{
    Resources_Health r_h;
    GameObject baseMachineGunTower;

    private void Awake()
    {
        r_h = Camera.main.GetComponent<Resources_Health>();
        baseMachineGunTower = Resources.Load("MachineGun_Lvl1") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (r_h.GetResources() < baseMachineGunTower.GetComponent<Towers>().TowerCost())
        {
            this.GetComponent<Image>().color = Color.red;
        }
        else
        {
            this.GetComponent<Image>().color = Color.white;
        }
    }
}
