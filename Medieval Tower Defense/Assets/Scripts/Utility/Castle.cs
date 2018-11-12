using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    Resources_Health health;

    private void Start()
    {
        health = Camera.main.GetComponent<Resources_Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            Destroy(other.gameObject, .1f);
            health.SetHealth(-1);
        }
    }
}
