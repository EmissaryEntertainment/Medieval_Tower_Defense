using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUpgradeButtonControls : MonoBehaviour
{
    Resources_Health r_h;
    public static int nextTowerCost = 200; // default value to avoid errors

    private void Awake()
    {
        r_h = Camera.main.GetComponent<Resources_Health>();
    }

    // Use this for initialization
    void Start ()
    { 

	}
	
	// Update is called once per frame
	void Update ()
    {
		if(r_h.GetResources() < nextTowerCost)
        {
            this.GetComponent<Image>().color = Color.red;
        }
        else
        {
            this.GetComponent<Image>().color = Color.white;
        }
	}
}
