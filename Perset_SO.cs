using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Preset",menuName ="Character Preset")]
public class Perset_SO : ScriptableObject
{
    public List<PersetSetting> settings = new List<PersetSetting>();
}

[System.Serializable]
public class PersetSetting
{
    public int torso, armUppeRight, armUpperLeft, armLowerRight, armLowerLeft, handRight, handLeft, legRight, legLeft, hips,shoulderRight, shouldLeft;
}
