using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    public TextMeshProUGUI TMP_Text;
    [SerializeField] TMP_InputField Input_Text;

    public void OnClickButton()
    {
        TMP_Text.text = Input_Text.text;
    }
}
