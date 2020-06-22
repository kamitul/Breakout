using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : PowerUp, IDropable
{

    [SerializeField]
    private int multiplierFactor = default;

    [SerializeField]
    private PointController pointManager = default;

    public void UpdateGame()
    {
        pointManager.MultiplyPoints(multiplierFactor);
        Destroy(gameObject);
    }
}
