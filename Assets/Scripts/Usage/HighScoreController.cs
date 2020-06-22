using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HighScoreController : MonoBehaviour
{

    [SerializeField]
    private Text[] highScorePoints = default;

    [SerializeField]
    private Text[] highScoreNames = default;

    private int counter = 0;

    private void OnEnable()
    {
        List<KeyValuePair<string, int>> scoreList = CSVReader.GetScoreFromCSV(Application.persistentDataPath + "/points.csv");
        counter = 0;
        foreach (var elem in scoreList)
        {
            if (counter < 4)
            {
                highScoreNames[counter].text = elem.Key;
                highScorePoints[counter].text = elem.Value.ToString();
                counter++;
            }
        }
        counter = 0;
    }
}
