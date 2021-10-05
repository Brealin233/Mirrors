using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Singleton<Character>
{
    CharacterPreset characterPreset;

    [Header("性别选择")]
    public GameObject male;
    public GameObject famale;

    [Header("通用选择")]
    public GameObject hair;
    public GameObject elfEar;
    public GameObject shoulderRight;
    public GameObject shoulderLeft;

    //身体部分
    private GameObject head;
    private GameObject eyebrows;
    private GameObject facialHair;

    //当前激活物体
    public GameObject activeObject;
    private bool toggleOpen;

    //当前物体序号
    private int currentIndex;

    //列表
    public List<GameObject> hairs, elfEars, heads,eyeBowses,facialHairs;

    protected override void Awake()
    {
        base.Awake();
        characterPreset = GetComponent<CharacterPreset>();
        SwitchGender(false);
    }

    private void InitCharacterPerts()
    {
        currentIndex = 0;

        head = activeObject.transform.GetChild(0).GetChild(0).gameObject;
        eyebrows = activeObject.transform.GetChild(1).gameObject;
        facialHair = activeObject.transform.GetChild(2).gameObject;

        hairs = new List<GameObject>();
        elfEars = new List<GameObject>();
        heads = new List<GameObject>();
        eyeBowses = new List<GameObject>();
        facialHairs = new List<GameObject>();

        GetAllChild(hair, hairs, false);
        GetAllChild(head, heads, true);
        GetAllChild(elfEar, elfEars, false);
        GetAllChild(eyebrows, eyeBowses, true);
        GetAllChild(facialHair, facialHairs, false);
        
    }

    public void SwitchGender(bool toggle)
    {
        
        toggleOpen = toggle;
        famale.SetActive(toggleOpen);
        male.SetActive(!toggleOpen);

        activeObject = toggle ? famale : male;

        characterPreset.CurrentGender = activeObject;
        characterPreset.Init();

        InitCharacterPerts();
    }

    /// <summary>
    /// 获取当前物体的所有子物体,可以设置是否默认显示第一个物体
    /// </summary>
    /// <param name="target">获取的目标物体</param>
    /// <param name="targetList">对应列表</param>
    /// <param name="baseActive">默认是否显示第一个物体</param>
    public void GetAllChild(GameObject target,List<GameObject> targetList,bool baseActive)
    {
        for (int i = 0; i < target.transform.childCount; i++)
        {
            targetList.Add(target.transform.GetChild(i).gameObject);
            //Debug.Log("?");
            if (baseActive == true)
            {
                target.transform.GetChild(0).gameObject.SetActive(true);
                if (i > 0)
                    target.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
                target.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    
    /// <summary>
    /// 切换到对应到物体
    /// </summary>
    /// <param name="targetList">目标列表</param>
    /// <param name="canEmpty">是否可以全部关闭</param>
    /// <param name="increase">是否增量</param>
    /// <param name="name">显示的信息</param>
    public void ChangeItem(List<GameObject> targetList,bool canEmpty,bool increase,ref string name)
    {
        int amount = increase ? 1 : -1;

        foreach (var item in targetList)
        {
            if (item.activeInHierarchy)
                currentIndex = item.transform.GetSiblingIndex();
        }

        currentIndex += amount;

        //一直按+号循环显示
        if(currentIndex >= targetList.Count && increase)
        {
            if (canEmpty)
                currentIndex = -1;
            else
                currentIndex = 0;
        }

        //一直按-号循环显示
        if(currentIndex <= 0 && !increase)
        {
            if (canEmpty)
                currentIndex = targetList.Count;
            else
                currentIndex = targetList.Count - 1;
        }
        
        for (int i = 0; i < targetList.Count; i++)
        {
            if(currentIndex >= 0 || currentIndex < targetList.Count)
            {
                if (i != currentIndex)
                    targetList[i].SetActive(false);
                else
                    targetList[i].SetActive(true);
            }
            else
                targetList[i].SetActive(false);
        }

        if (currentIndex > targetList.Count && currentIndex < 0)
            name = "None";
        else
            name = currentIndex.ToString();
    }
}  
