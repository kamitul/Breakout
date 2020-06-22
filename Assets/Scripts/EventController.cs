using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public UnityEvent GameOver;
    public UnityEvent GameWon;
    public UnityEvent GameLifeLoose;

    private int prevLifes = 3;

    private void OnEnable()
    {
        GameManager.Instance.GameData.DataChanged += CheckGameStatus;
        GameOver.AddListener(GameManager.Instance.EndGame);
        GameWon.AddListener(GameManager.Instance.CompleteLevel);
    }

    private void CheckGameStatus(GameData obj)
    {
        if(prevLifes > obj.Lifes)
        {
            GameLifeLoose.Invoke();
            prevLifes = obj.Lifes;
        }
        if (obj.Lifes <= 0)
        {
            GameOver.Invoke();
        }
        if (obj.Points >= obj.MaxPoints)
        {
            GameManager.Instance.GameData.PointsCollected.Add(obj.Points);
            obj.Points = 0;
            obj.MaxPoints = int.MaxValue;
            GameWon.Invoke();
        }
    }

    private void OnDisable()
    {
        GameManager.Instance.GameData.DataChanged -= CheckGameStatus;
    }
}
