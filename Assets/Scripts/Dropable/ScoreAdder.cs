using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : PowerUp, IDropable
{
    [SerializeField]
    private int pointsAmount = default;

    [SerializeField]
    private PointController pointManager = default;

    private void Update()
    {
        transform.Rotate(0f, 3f * Time.deltaTime, 0f);
    }

    public void UpdateGame()
    {
        pointManager.IncrementScore(pointsAmount);
        Destroy(gameObject);
    }
}
