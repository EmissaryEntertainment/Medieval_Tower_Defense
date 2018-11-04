using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[System.Serializable]
public class AutomatedTest
{
    List<MouseEvents> mousePosition = new List<MouseEvents>();
    string jSon;
    private string FilePath;

    //the following code is called each time an event happens and stores the mouse position

    public void StoreMousePosition(MouseEvents _mouse)
    {
        //comment out in order to disable the capture during playback

        //FilePath = Path.Combine(Application.persistentDataPath, "AutomatedTestData.txt");
        //jSon = JsonUtility.ToJson(_mouse);
        //using (StreamWriter streamWriter = new StreamWriter(FilePath, true))
        //{
        //    streamWriter.Write(jSon);
        //}
    }

    //this is called at the beginning of the game and creates a list of mouse positions that get iterated through to automatically play the game.
    public void ReadMousePositionFromJson()
    {
        FilePath = Path.Combine(Application.persistentDataPath, "AutomatedTestData.txt");
        string fromJsonString;
        using (StreamReader streamReader = File.OpenText(FilePath))
        {
            while ((fromJsonString = streamReader.ReadLine()) != null)
            {
                mousePosition.Add(JsonUtility.FromJson<MouseEvents>(fromJsonString));
            }
        }
    }

    public MouseEvents ReturnMouseEventObj(int _i)
    {
        return mousePosition[_i];
    }

}

public class MouseEvents
{
    public float posX;
    public float posY;
    public bool mouseClick;
    public int gameTicks;


    public MouseEvents(float _posX,float _posY,bool _mouseClick,int _gameTicks)
    {
        posX = _posX;
        posY = _posY;
        mouseClick = _mouseClick;
        gameTicks = _gameTicks;
    }
}