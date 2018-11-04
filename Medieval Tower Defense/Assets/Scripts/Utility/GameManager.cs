using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class GameManager : MonoBehaviour
{
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);


    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(long dwFlags, float dx, float dy, long cButtons, long dwExtraInfo);

    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;
    private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
    private const int MOUSEEVENTF_RIGHTUP = 0x10;

    AutomatedTest readBackInputs = new AutomatedTest();
    int testTicks = 0;
    int i = 0;

	// Use this for initialization
	void Start ()
    {
        readBackInputs.ReadMousePositionFromJson();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        testTicks++;
        Debug.Log(Input.mousePosition);
        if (readBackInputs.ReturnMouseEventObj(i) != null)
        {
            if (readBackInputs.ReturnMouseEventObj(i).gameTicks == testTicks)
            {
                SetCursorPos(Mathf.RoundToInt(readBackInputs.ReturnMouseEventObj(i).posX), Mathf.RoundToInt(readBackInputs.ReturnMouseEventObj(i).posY));
                if (readBackInputs.ReturnMouseEventObj(i).mouseClick == true)
                {
                    DoMouseClick(Mathf.RoundToInt(readBackInputs.ReturnMouseEventObj(i).posX), Mathf.RoundToInt(readBackInputs.ReturnMouseEventObj(i).posY));
                }
                i++;

            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
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

    public void DoMouseClick(int _X,int _Y)
    {
        //Call the imported function with the cursor's current position
        int X = _X;
        int Y = _Y;
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
    }
}
