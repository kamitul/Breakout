using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallSpeederType
{
    SPEED,
    SLOW
}

public class BallSpeeder : PowerUp, IDropable
{
    [SerializeField]
    private BallController ballController = default;

    [SerializeField]
    private BallSpeederType ballSpeederType = default;

    public float Duration = 4f;

    public void UpdateGame()
    {
        switch (ballSpeederType)
        {
            case BallSpeederType.SPEED:
                StartCoroutine(SpeedUpBall());
                break;
            case BallSpeederType.SLOW:
                StartCoroutine(SpeedDownBall());
                break;
        }
        Destroy(gameObject);
    }


    private IEnumerator SpeedUpBall()
    {
        float rand = UnityEngine.Random.Range(1f, 2f);
        ballController.GetComponent<Rigidbody>().velocity *= rand;
        yield return new WaitForSeconds(Duration);
        ballController.GetComponent<Rigidbody>().velocity /= rand;
    }

    private IEnumerator SpeedDownBall()
    {
        float rand = UnityEngine.Random.Range(2f, 4f);
        ballController.GetComponent<Rigidbody>().velocity /= rand;
        yield return new WaitForSeconds(Duration);
        ballController.GetComponent<Rigidbody>().velocity *= rand;
    }
}
