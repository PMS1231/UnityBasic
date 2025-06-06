using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image img_HPbar;
    public TextMeshProUGUI TXT_txt;
    public TextMeshProUGUI TXT_HPtxt;
    int maxHP =100;
    int nowHP;
    private int Damage;
    public int HealPoint;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        nowHP = maxHP;
        img_HPbar.fillAmount = nowHP;
    }
    public void GetDamage()
    {
        Damage = Random.Range(0, 20);
        nowHP -= Damage;
        img_HPbar.fillAmount = (float)nowHP/maxHP;
        TXT_txt.text = $"��! �̰� ���� ������! -{Damage}";
        TXT_HPtxt.text = $"{nowHP}%";
    }

    public void GetHeal()
    {
        nowHP += HealPoint;
        img_HPbar.fillAmount = (float)nowHP /maxHP;
        TXT_txt.text = $"������ ������ ���Ⱑ ���ƿ´�! +{HealPoint}";
        TXT_HPtxt.text = $"{nowHP}%";
    }
}
