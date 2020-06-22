using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReseterController : MonoBehaviour
{
    public List<GameObject> resetables;

    private void Awake()
    {
        ResetState();
    }

    public void ResetState()
    {
        for (int i = 0; i < resetables.Count; ++i)
        {
            (resetables[i].GetComponent<IResetable>()).ResetState();
        }
    }
}
