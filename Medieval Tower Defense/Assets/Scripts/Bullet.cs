using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class attached to each bullet that controls it's target and path
/// </summary>
public class Bullet : MonoBehaviour
{
    Towers parentTower;
    Transform enemyPosition;
    public float bulletSpeed;

    private void Start()
    {
        parentTower = this.transform.GetComponentInParent<Towers>();
        enemyPosition = parentTower.GetEnemyPosition().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyPosition != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyPosition.position, bulletSpeed * Time.deltaTime);
            transform.LookAt(enemyPosition.position);
            Destroy(gameObject, .5f);
        }
        if(enemyPosition == null)
        {
            Destroy(gameObject, .01f);
        }
    }
}
