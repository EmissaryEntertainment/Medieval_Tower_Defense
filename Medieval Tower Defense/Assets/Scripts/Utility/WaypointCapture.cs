using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCapture : MonoBehaviour
{
    private static Transform[] wayPoints;

    private void Awake()
    {
        wayPoints = new Transform[transform.childCount];
        for(int i = 0; i<wayPoints.Length; i++)
        {
            wayPoints[i] = transform.GetChild(i);
        }
    }

    public Transform GetWaypoints(int i)
    {
        return wayPoints[i];
    }
}
