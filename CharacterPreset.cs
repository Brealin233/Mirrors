using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPreset : MonoBehaviour
{
    public Perset_SO presetDate;

    public GameObject CurrentGender { set; get; }
    List<GameObject> torso, armUppeRight, armUpperLeft, armLowerRight, armLowerLeft, handRight, handLeft, legRight, legLeft, hips,shoulderRight, shouldLeft;

    public void Init()
    {
        torso = new List<GameObject>();
        armUppeRight = new List<GameObject>();
        armUpperLeft = new List<GameObject>();
        armLowerRight = new List<GameObject>();
        armLowerLeft = new List<GameObject>();
        handRight = new List<GameObject>();
        handLeft = new List<GameObject>();
        legRight = new List<GameObject>();
        legLeft = new List<GameObject>();
        hips = new List<GameObject>();
        shoulderRight = new List<GameObject>();
        shouldLeft = new List<GameObject>();

        GetAllParts();
    }

    void GetAllParts()
    {
        Character.Instance.GetAllChild(CurrentGender.transform.GetChild(3).gameObject, torso, true);
        Character.Instance.GetAllChild(CurrentGender.transform.GetChild(4).gameObject, armUppeRight, true);
        Character.Instance.GetAllChild(CurrentGender.transform.GetChild(5).gameObject, armUpperLeft, true);
        Character.Instance.GetAllChild(CurrentGender.transform.GetChild(6).gameObject, armLowerRight, true);
        Character.Instance.GetAllChild(CurrentGender.transform.GetChild(7).gameObject, armLowerLeft, true);
        Character.Instance.GetAllChild(CurrentGender.transform.GetChild(8).gameObject, handRight, true);
        Character.Instance.GetAllChild(CurrentGender.transform.GetChild(9).gameObject, handLeft, true);
        Character.Instance.GetAllChild(CurrentGender.transform.GetChild(10).gameObject, hips, true);
        Character.Instance.GetAllChild(CurrentGender.transform.GetChild(11).gameObject, legRight, true);
        Character.Instance.GetAllChild(CurrentGender.transform.GetChild(12).gameObject, legLeft, true);
        Character.Instance.GetAllChild(Character.Instance.shoulderRight, shoulderRight, false);
        Character.Instance.GetAllChild(Character.Instance.shoulderLeft, shouldLeft, false);
    }

    public void GetChanged(int preset)
    {
        SetCharacterPerset(torso, presetDate.settings[preset].torso);
        SetCharacterPerset(armUppeRight, presetDate.settings[preset].armUppeRight);
        SetCharacterPerset(armUpperLeft, presetDate.settings[preset].armUpperLeft);
        SetCharacterPerset(armLowerRight, presetDate.settings[preset].armLowerRight);
        SetCharacterPerset(armLowerLeft, presetDate.settings[preset].armLowerLeft);
        SetCharacterPerset(handRight, presetDate.settings[preset].handRight);
        SetCharacterPerset(handLeft, presetDate.settings[preset].handLeft);
        SetCharacterPerset(hips, presetDate.settings[preset].hips);
        SetCharacterPerset(legRight, presetDate.settings[preset].legRight);
        SetCharacterPerset(legLeft, presetDate.settings[preset].legLeft);
        SetCharacterPerset(shoulderRight, presetDate.settings[preset].shoulderRight);
        SetCharacterPerset(shouldLeft, presetDate.settings[preset].shouldLeft);
    }

    /// <summary>
    /// 找到目标列表中对应的物体显示出来
    /// </summary>
    /// <param name="targetList">目标物体</param>
    /// <param name="presetIndex">perset中对应的序号</param>
    void SetCharacterPerset(List<GameObject> targetList,int presetIndex)
    {
        for (int i = 0; i < targetList.Count; i++)
        {
            if (i == presetIndex)
                targetList[i].gameObject.SetActive(true);
            else
                targetList[i].gameObject.SetActive(false);
        }
    }
}

