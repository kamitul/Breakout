using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDuplicater : PowerUp, IDropable
{
    [SerializeField]
    private GameObject ballToCopy = default;

    [SerializeField]
    private GameObject ballToClone = default;

    [HideInInspector]
    [SerializeField]
    private GameObject additionalBall = default;

    public void UpdateGame()
    {
        StartCoroutine(CreateAdditionalBall());
    }

    private IEnumerator CreateAdditionalBall()
    {
        SpawnDuplicateBall();

        yield return new WaitForSeconds(4f);

        Destroy(additionalBall);
        Destroy(gameObject);
    }

    private void SpawnDuplicateBall()
    {
        additionalBall = Instantiate<GameObject>(ballToClone);
        additionalBall.transform.position = ballToCopy.GetComponent<Transform>().position + new Vector3(1f, 1f, 0f);
        additionalBall.GetComponent<Rigidbody>().velocity = ballToCopy.GetComponent<Rigidbody>().velocity;
    }
}
