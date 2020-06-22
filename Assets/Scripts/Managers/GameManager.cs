using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Runtime.CompilerServices;

[System.Serializable]
public class GameData
{
    public Action<GameData> DataChanged;

    [SerializeField]
    private int lifes;
    [SerializeField]
    private float time;
    [SerializeField]
    private int points;
    [SerializeField]
    private Skill activeSkill;
    [SerializeField]
    private string playerName;
    [SerializeField]
    private int level;

    public int MaxPoints;
    public List<int> PointsCollected = new List<int>();

    public int Lifes
    {
        get => lifes;
        set
        {
            lifes = value;
            DataChanged?.Invoke(this);
        }
    }

    public float Time
    {
        get => time;
        set
        {
            time = value;
            DataChanged?.Invoke(this);
        }
    }

    public int Points
    {
        get => points;
        set
        {
            points = value;
            DataChanged?.Invoke(this);
        }
    }

    public Skill ActiveSkill
    {
        get => activeSkill;
        set
        {
            activeSkill = value;
            DataChanged?.Invoke(this);
        }
    }

    public string PlayerName
    {
        get => playerName;
        set
        {
            playerName = value;
            DataChanged?.Invoke(this);
        }
    }

    public int Level
    {
        get => level;
        set
        {
            level = value;
            DataChanged?.Invoke(this);
        }
    }

    public void Tick(float time)
    {
        Time += time;
    }
}


public class GameManager : Singleton<GameManager>
{
    public GameData GameData;

    protected override void Awake()
    {
        base.Awake();
        GameData = new GameData();
        ResetState();
    }

    private void Update()
    {
        GameData.Tick(Time.deltaTime);
    }

    public void EndGame()
    {
        Time.timeScale = 0;
    }

    public void ResetState()
    {
        Time.timeScale = 1;
        GameData.Lifes = 3;
        GameData.Points = 0;
        GameData.Time = 0;
        GameData.Level = 0;
    }

    public void LooseLife()
    {
        GameData.Lifes--;
    }

    public void CompleteLevel()
    {
        GameData.Level++;
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
