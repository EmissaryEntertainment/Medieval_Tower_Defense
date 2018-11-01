﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : TowerClass
{
    private GameObject rangeIdentifier; // used to set the range of the turret
    private Tower thisTower; // used in start with the Tower constructor to store this towers information from the parent class
    private string towerTag; // used to store tag in order to pass it into the constructor
    private Transform enemyPosition; // stores enemy positions when they come within the towers range
    private float bulletTimer; // adds to time.deltatime to compare against timeBetweenBullets for how fast the turret can fire

    Resources_Health R_H; // used to access the Resource_Health script for upgrading turret

    public float timeBetweenBullets; // The fire rate of the turret
    public int towerCost; // used for taking resources from the player when instantiating or upgrading a turret
    public GameObject bullet; // the bullet gameobject the turret will insantiate

    // Use this for initialization
    void Start ()
    {
        towerTag = this.tag;
        rangeIdentifier = transform.Find("RangeIdentifier").gameObject;
        thisTower = new Tower(towerTag, rangeIdentifier, towerCost);
        R_H = Camera.main.GetComponent<Resources_Health>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        bulletTimer += Time.deltaTime;
        if (Physics.CheckSphere(transform.position, thisTower.GetAttackRange(), 1 << 9))
        {
            Collider[] enemy = Physics.OverlapSphere(transform.position, thisTower.GetAttackRange(), 1 << 9);
            thisTower.TrackTarget(transform.Find("Turret"), enemy[0].transform);
            enemyPosition = enemy[0].transform;
            if(bulletTimer > timeBetweenBullets)
            {
                Instantiate(bullet, transform.Find("Turret").transform.Find("Barrel").position, transform.Find("Turret").transform.Find("Barrel").rotation, transform);
                bulletTimer = 0;
            }
            Debug.Log("tracking enemy");
        }
    }

    private void OnMouseEnter()
    {
        thisTower.SetRangeIdentifier(thisTower.GetAttackRange());
    }

    private void OnMouseDown()
    {
        if (thisTower.GetNextTower().GetComponent<Towers>().TowerCost() <= R_H.GetResources())
        {
            R_H.SetResources(-thisTower.GetNextTower().GetComponent<Towers>().TowerCost());
            thisTower.UpgradeTower(this.gameObject);
            Destroy(gameObject, .01f);
        }
    }

    private void OnMouseExit()
    {
        thisTower.SetRangeIdentifier(0);
    }

    public Transform GetEnemyPosition()
    {
        return enemyPosition;
    }
    public int TowerCost()
    {
        return towerCost;
    }
}
