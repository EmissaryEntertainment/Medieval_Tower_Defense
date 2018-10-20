using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
    GameObject baseTower;

    private void Start()
    {
        baseTower = Resources.Load("MachineGun_Lvl1") as GameObject;
    }

    private void OnMouseDown()
    {
        Instantiate(baseTower, this.transform.position + new Vector3(0,1,0), this.transform.rotation);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
