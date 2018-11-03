using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[System.Serializable]
public class AutomatedTest
{
    List<MouseEvents> mousePosition = new List<MouseEvents>();
    List<string> mousePosJson = new List<string>();
    private string FilePath;

    public void StoreMousePosition(MouseEvents _mouse)
    {
        mousePosition.Add(_mouse);
        Debug.Log(mousePosition.Count - 1);
        mousePosJson.Add(JsonUtility.ToJson(mousePosition[mousePosition.Count-1]));
        Debug.Log(JsonUtility.FromJson<MouseEvents>(mousePosJson[0]).posX +":"+ JsonUtility.FromJson<MouseEvents>(mousePosJson[0]).posY + ":" + JsonUtility.FromJson<MouseEvents>(mousePosJson[0]).mouseClick +":"+ JsonUtility.FromJson<MouseEvents>(mousePosJson[0]).gameTicks);
    }

    public void SaveData()
    {
        FilePath = Application.persistentDataPath;
        for(int i = 0;i<mousePosJson.Count;i++)
        {
            File.WriteAllText(FilePath, mousePosJson[i]);
        }
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