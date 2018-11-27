using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserTurretSpawnButtonControler : MonoBehaviour
{
    Resources_Health r_h;
    GameObject baseLaserTower;

    private void Awake()
    {
        r_h = Camera.main.GetComponent<Resources_Health>();
        baseLaserTower = Resources.Load("LaserTower_Lvl1") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (r_h.GetResources() < baseLaserTower.GetComponent<Towers>().TowerCost())
        {
            this.GetComponent<Image>().color = Color.red;
        }
        else
        {
            this.GetComponent<Image>().color = Color.white;
        }
    }
}
