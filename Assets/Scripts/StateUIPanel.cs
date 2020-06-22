using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateUIPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI label = default;

    [SerializeField]
    private TMP_InputField inputField = default;

    public void SetWinText(float points)
    {
        label.text = "Hurray!, You won! \n +" +
            "Your score: " + points.ToString();
    }

    public void SetLostText(float points)
    {
        label.text = "Unfortunatley!, You lost! \n +" +
            "Your score: " + points.ToString();
    }

    public void SetPlayerName()
    {
        GameManager.Instance.GameData.PlayerName = inputField.text;
    }
}
