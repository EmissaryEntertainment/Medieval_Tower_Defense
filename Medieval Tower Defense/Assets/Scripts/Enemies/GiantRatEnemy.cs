using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiantRatEnemy : MonoBehaviour
{
    Slider healthBar;

    WaypointCapture waypoint;

    int i = 0;

	// Use this for initialization
	void Start ()
    {
        healthBar = transform.Find("RatHealth").transform.Find("Healthbar").GetComponent<Slider>();
        waypoint = GameObject.FindGameObjectWithTag("WaypointParent").GetComponent<WaypointCapture>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint.GetWaypoints(i).position, Random.Range(3,9) * Time.deltaTime);
        transform.LookAt(waypoint.GetWaypoints(i).position);
        if (transform.position == waypoint.GetWaypoints(i).position)
        {
            i++;
        }
        if(healthBar.value <= 0)
        {
            Destroy(gameObject, .01f);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            healthBar.value -= 20;
            Destroy(other.gameObject, .01f);
        }
    }
}
