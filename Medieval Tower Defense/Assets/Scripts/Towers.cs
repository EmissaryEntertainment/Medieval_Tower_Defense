using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : TowerClass
{
    public int attackPower;
    public int towerCost;
    public int attackRange;
    GameObject rangeIdentifier;
    Tower thisTower;

    // Use this for initialization
    void Start ()
    {
        rangeIdentifier = transform.GetChild(0).gameObject;
        thisTower = new Tower(attackPower, towerCost, attackRange, rangeIdentifier);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Physics.CheckSphere(transform.position, thisTower.GetAttackRange(), 1 << 9))
        {
            Collider[] enemy = Physics.OverlapSphere(transform.position, thisTower.GetAttackRange(), 1 << 9);
            thisTower.TrackTarget(transform, enemy[0].transform);
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
