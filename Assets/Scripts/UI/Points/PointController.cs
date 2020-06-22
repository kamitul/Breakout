using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointController : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.GameData.Points = 0;
    }

    public void IncrementScore(int points)
    {
        GameManager.Instance.GameData.Points += points;
    }

    public void MultiplyPoints(int factor)
    {
        GameManager.Instance.GameData.Points *= factor;
    }
}
