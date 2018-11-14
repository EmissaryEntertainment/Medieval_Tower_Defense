using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Resources_Health : MonoBehaviour
{
    int resources = 300;
    int health = 10;

    Text resourceText;
    Text healthText;

    // Use this for initialization
    void Start ()
    {
        resourceText = GameObject.FindGameObjectWithTag("Resources_Text").GetComponent<Text>();
        healthText = GameObject.FindGameObjectWithTag("Health_Text").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        resourceText.text = resources.ToString();
        healthText.text = health.ToString();
        if(GetHealth() <=0)
        {
            SceneManager.LoadScene(1);
        }
	}

    public void SetHealth(int _healthValue)
    {
        health += _healthValue;
    }
    public int GetHealth()
    {
        return health;
    }
    public void SetResources(int _resourceValue)
    {
        resources += _resourceValue;
    }
    public int GetResources()
    {
        return resources;
    }
}
