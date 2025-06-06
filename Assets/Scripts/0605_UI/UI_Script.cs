using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Script : MonoBehaviour
{
    public TextMeshProUGUI Txt_Text;
    public string nextText;

    public void OnClickButton()
    {
            Txt_Text.text = nextText;
    }
}
