using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text points = default;

    [SerializeField]
    private Text time = default;

    [SerializeField]
    private Text level = default;

    [SerializeField]
    private GameObject[] lifes = default;

    [SerializeField]
    private GameObject[] skills = default;

    [SerializeField]
    private GameObject statePanel = default;

    private Skill prevSkill;

    private void OnEnable()
    {
        GameManager.Instance.GameData.DataChanged += UpdateUI;
    }

    private void OnDisable()
    {
        GameManager.Instance.GameData.DataChanged -= UpdateUI;
    }

    private void UpdateUI(GameData obj)
    {
        UpdateStatisticsUI(obj);
        UpdateHealthUI(obj);
        UpdateSkillUI(obj);
    }

    private void UpdateHealthUI(GameData obj)
    {
        for (int i = 0; i < lifes.Length; ++i)
        {
            lifes[i].SetActive(false);
        }
        for (int i = 0; i < obj.Lifes; ++i)
        {
            lifes[i].SetActive(true);
        }
    }

    private void UpdateStatisticsUI(GameData obj)
    {
        points.text = obj.Points.ToString();
        time.text = Math.Round(obj.Time, 2).ToString();
        level.text = obj.Level.ToString();
    }

    private void UpdateSkillUI(GameData obj)
    {
        Skill activeSkill = obj.ActiveSkill;
        if (activeSkill)
            StartCoroutine(SkillCooldownUI(GetImage(activeSkill), activeSkill.Data.Cooldown));
    }

    private Image GetImage(Skill activeSkill)
    {
        if (activeSkill as BallReflector)
            return skills[2].GetComponent<Image>();
        if (activeSkill as ProjectileLauncher)
            return skills[0].GetComponent<Image>();
        if (activeSkill as BrickDestroyer)
            return skills[1].GetComponent<Image>();

        return null;
    }

    private IEnumerator SkillCooldownUI(Image image, float cooldown)
    {
        if (image.fillAmount == 0)
        {
            while (true)
            {
                image.fillAmount += 1.0f / cooldown * Time.deltaTime;
                yield return new WaitForEndOfFrame();
                if (image.fillAmount >= 1f)
                {
                    image.fillAmount = 0f;
                    break;
                }
            }
        }
    }

    public void LostGameUI()
    {
        statePanel.SetActive(true);
        statePanel.GetComponent<StateUIPanel>().SetLostText(GameManager.Instance.GameData.Points);
    }

    public void WonGameUI()
    {
        statePanel.SetActive(true);
        statePanel.GetComponent<StateUIPanel>().SetWinText(GameManager.Instance.GameData.Points);
    }

    public void ExitToMainMenu()
    {
        GameManager.Instance.ExitToMainMenu();
    }
}
