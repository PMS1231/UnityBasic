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
        TXT_txt.text = $"악! 이건 정말 아프다! -{Damage}";
        TXT_HPtxt.text = $"{nowHP}%";
    }

    public void GetHeal()
    {
        nowHP += HealPoint;
        img_HPbar.fillAmount = (float)nowHP /maxHP;
        TXT_txt.text = $"저놈의 몸에서 생기가 돌아온다! +{HealPoint}";
        TXT_HPtxt.text = $"{nowHP}%";
    }
}
