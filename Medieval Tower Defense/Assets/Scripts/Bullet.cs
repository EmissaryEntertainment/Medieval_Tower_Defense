using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Towers parentTower;
    public float bulletSpeed;

    private void Start()
    {
        parentTower = this.transform.GetComponentInParent<Towers>();
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = Vector3.MoveTowards(transform.position, parentTower.GetEnemyPosition().transform.position, bulletSpeed * Time.deltaTime);
    }
}
