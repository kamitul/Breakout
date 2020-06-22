using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    private class SkillHandler
    {
        public KeyCode Key;
        public Skill Behaviour;
        public float Timer;

        public SkillHandler(KeyCode key, Skill behaviour, float timer)
        {
            Key = key;
            Behaviour = behaviour;
            Timer = timer;
        }
    }

    [SerializeField]
    private List<SkillHandler> skills;

    private void Awake()
    {
        skills = new List<SkillHandler>()
        {
            new SkillHandler(KeyCode.J, GetComponentInChildren<ProjectileLauncher>(), 50f),
            new SkillHandler(KeyCode.K, GetComponentInChildren<BrickDestroyer>(), 50f),
            new SkillHandler(KeyCode.L, GetComponentInChildren<BallReflector>(), 50f),
        };
    }

    private void Update()
    {
        for (int i = 0; i < skills.Count; ++i)
        {
            skills[i].Timer += Time.deltaTime;
            if (Input.GetKeyDown(skills[i].Key))
            {
                skills[i].Behaviour.Preform(ref skills[i].Timer);
            }
        }
    }
}
