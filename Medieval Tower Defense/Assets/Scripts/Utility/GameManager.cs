using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System;

public class GameManager : MonoBehaviour
{
    public Dropdown dropdownMenu;

    public GameObject optionsMenu;

    [XmlAttribute("Resolution")]
    int dropdownValue;

    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);


    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(long dwFlags, float dx, float dy, long cButtons, long dwExtraInfo);

    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;
    private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
    private const int MOUSEEVENTF_RIGHTUP = 0x10;

    //AutomatedTest readBackInputs = new AutomatedTest();
    int testTicks = 0;
    int i = 0;

    // Use this for initialization
    void Start()
    {
        //readBackInputs.ReadMousePositionFromJson();
        LoadData();
        dropdownMenu.value = dropdownValue;
        optionsMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && optionsMenu.activeInHierarchy == false)
        {
            Time.timeScale = 0;
            optionsMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && optionsMenu.activeInHierarchy == true)
        {
            Time.timeScale = 1;
            optionsMenu.SetActive(false);
        }

        SetResolution();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //testTicks++;
        //if (readBackInputs.ReturnMouseEventObj(i) != null)
        //{
        //    if (readBackInputs.ReturnMouseEventObj(i).gameTicks == testTicks)
        //    {
        //        SetCursorPos(Mathf.RoundToInt(readBackInputs.ReturnMouseEventObj(i).posX), Mathf.RoundToInt(readBackInputs.ReturnMouseEventObj(i).posY));
        //        if (readBackInputs.ReturnMouseEventObj(i).mouseClick == true)
        //        {
        //            DoMouseClick(Mathf.RoundToInt(readBackInputs.ReturnMouseEventObj(i).posX), Mathf.RoundToInt(readBackInputs.ReturnMouseEventObj(i).posY));
        //        }
        //        i++;

        //    }
        //}

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

    /// <summary>
    /// Sets the game resloution based on the dropdown menu value
    /// </summary>
    public void SetResolution()
    {
        if (dropdownMenu.value == 0)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if (dropdownMenu.value == 1)
        {
            Screen.SetResolution(1280, 720, true);
        }
        else if (dropdownMenu.value == 2)
        {
            Screen.SetResolution(640, 480, true);
        }
    }

    public void DoMouseClick(int _X, int _Y)
    {
        //Call the imported function with the cursor's current position
        int X = _X;
        int Y = _Y;
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
    }

    public void ExitGame()
    {
        SaveData();
        Application.Quit();
    }

    /*
     * Using int dropdownValue in start function to set the dropdown menu's value to the same value that is read back from the xml file
     */

    /// <summary>
    /// Saves current screen resolution drop down menu selection to an xml file
    /// </summary>
    public void SaveData()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(string)); // type of data you want to save
        FileStream stream = new FileStream(Application.dataPath + "ScreenResolution.xml", FileMode.Create); // filepath to create new xml file at
        serializer.Serialize(stream, dropdownMenu.value.ToString()); // which variable to save
        stream.Close();
    }

    /// <summary>
    /// Loads the xml file that is saved in application.datapath and sets the dropdown menu to that value
    /// </summary>
    public void LoadData()
    {
        string temp;
        XmlSerializer serializer = new XmlSerializer(typeof(string));
        FileStream stream = new FileStream(Application.dataPath + "ScreenResolution.xml", FileMode.Open); // where to open xml from
        temp = serializer.Deserialize(stream) as string; // used to read back string since you cant read back an int
        dropdownValue = Convert.ToInt32(temp); //convert read back string to an int
        stream.Close();
    }
}
