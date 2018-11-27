using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Attached to each GiantRat controlling its pathing ai
/// </summary>
public class GiantRatEnemy : MonoBehaviour
{
    Slider healthBar;

    WaypointCapture waypoint;

    Resources_Health R_H;

    int i = 0;

	// Use this for initialization
	void Start ()
    {
        healthBar = transform.Find("RatHealth").transform.Find("Healthbar").GetComponent<Slider>();
        waypoint = GameObject.FindGameObjectWithTag("WaypointParent").GetComponent<WaypointCapture>();
        R_H = Camera.main.GetComponent<Resources_Health>();

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
            R_H.SetResources(50);
            Destroy(gameObject, .01f);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            healthBar.value -= 10;
            Destroy(other.gameObject, .01f);
        }
    }
}
