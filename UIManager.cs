using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI hairText, headText, elfEartext, eyebrowsText, facialText;

    private string hairName, headName, elfEarName, eyebrowsName, facialName;

    private void Update()
    {
        hairText.text = hairName;
        headText.text = headName;
        elfEartext.text = elfEarName;
        eyebrowsText.text = eyebrowsName;
        facialText.text = facialName;
    }

    #region UI Button Action
    public void OpenFemale()
    {
        Character.Instance.SwitchGender(true);
    }

    public void OpenMale()
    {
        Character.Instance.SwitchGender(false);
    }

    public void HairIncrease()
    {
        Character.Instance.ChangeItem(Character.Instance.hairs, true, true, ref hairName);
    }

    public void HairDecrease()
    {
        Character.Instance.ChangeItem(Character.Instance.hairs, true, false, ref hairName);
    }

    #endregion
}
