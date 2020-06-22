using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBooster : PowerUp, IDropable
{
    public void UpdateGame()
    {
        Destroy(gameObject);

    }
}

