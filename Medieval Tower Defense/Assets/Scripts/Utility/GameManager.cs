using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            // enable pause menu
        }

        if(Input.GetKeyDown(KeyCode.Escape)/* && pause menu is enabled*/)
        {
            Time.timeScale = 1;
            // disable pause menu
        }
	}

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void DoubleGameSpeed()
    {
        Time.timeScale = 2;
    }
    public void PlayNormalSpeed()
    {
        Time.timeScale = 1;
    }
}
