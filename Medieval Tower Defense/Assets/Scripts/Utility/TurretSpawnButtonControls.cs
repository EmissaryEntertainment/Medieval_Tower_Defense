using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretSpawnButtonControls : MonoBehaviour
{
    Resources_Health r_h;
    GameObject baseTower;

    private void Awake()
    {
        r_h = Camera.main.GetComponent<Resources_Health>();
        baseTower = Resources.Load("MachineGun_Lvl1") as GameObject;
    }

    // Use this for initialization
    void Start ()
    { 

	}
	
	// Update is called once per frame
	void Update ()
    {
		if(r_h.GetResources() < baseTower.GetComponent<Towers>().TowerCost())
        {
            this.GetComponent<Image>().color = Color.red;
        }
        else
        {
            this.GetComponent<Image>().color = Color.white;
        }
	}
}
