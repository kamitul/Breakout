using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataCollector : Singleton<DataCollector>
{
    public bool LoadData = false;
    public static Action<string> SaveWarning;

    protected override void Awake()
    {
        base.Awake();
    }

    public bool SetLoadData(bool toggle)
    {
        if (!toggle)
        {
            LoadData = toggle;
            return true;
        }

        if (File.Exists(Application.persistentDataPath + "/game_state.json"))
        { LoadData = toggle; return true; }
        else
        { SaveWarning.Invoke("Save data doesn't exist!! "); return false; }
    }
}
