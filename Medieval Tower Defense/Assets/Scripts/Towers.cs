using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : TowerClass
{
    GameObject rangeIdentifier;
    Tower thisTower;
    string towerTag;

    // Use this for initialization
    void Start ()
    {
        towerTag = this.tag;
        rangeIdentifier = transform.Find("RangeIdentifier").gameObject;
        thisTower = new Tower(towerTag, rangeIdentifier);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Physics.CheckSphere(transform.position, thisTower.GetAttackRange(), 1 << 9))
        {
            Collider[] enemy = Physics.OverlapSphere(transform.position, thisTower.GetAttackRange(), 1 << 9);
            thisTower.TrackTarget(transform.Find("Turret"), enemy[0].transform);
            Debug.Log("tracking enemy");
        }
    }

    private void OnMouseEnter()
    {
        thisTower.SetRangeIdentifier(thisTower.GetAttackRange());
    }

    private void OnMouseExit()
    {
        thisTower.SetRangeIdentifier(0);
    }
}
