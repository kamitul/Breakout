using Paddle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DownBarController>())
        {
            Destroy(gameObject, 10f);
        }
        else if (other.GetComponentInParent<PaddleController>())
        {
            GetComponent<IDropable>().UpdateGame();
        }
    }
}
