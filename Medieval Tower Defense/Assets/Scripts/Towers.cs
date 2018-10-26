using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : TowerClass
{
    private GameObject rangeIdentifier;
    private Tower thisTower;
    private string towerTag;
    private GameObject bullet;
    private Transform enemyPosition;
    Resources_Health R_H;
    private float bulletTimer;
    public float timeBetweenBullets;
    public int towerCost;

    // Use this for initialization
    void Start ()
    {
        towerTag = this.tag;
        bullet = Resources.Load("Bullet") as GameObject;
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
