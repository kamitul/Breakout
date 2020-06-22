using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SkillData
{
    public float Cooldown;
    //...
}

public abstract class Skill : MonoBehaviour
{
    public SkillData Data;
    public virtual void Preform(ref float timer)
    {

    }
}
