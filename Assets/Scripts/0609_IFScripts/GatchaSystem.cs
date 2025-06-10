using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GatchaSystem : MonoBehaviour
{
    // ��í Ƚ�� �� Ȯ�� �ؽ�Ʈ
    public TextMeshProUGUI count_Text;
    public TextMeshProUGUI rate_Text;

    // ��í ��� �ؽ�Ʈ 
    public TextMeshProUGUI[] resultTextObjects;

    // ��í ���â ��� 
    public UnityEngine.UI.Image[] resultBGObjects;

    // ��í ���â ����
    Color star3Color = new Color32(79, 133, 255, 255);  // �Ķ���
    Color star4Color = new Color32(255, 218, 82, 255);  // �����
    Color star5Color = new Color32(255, 135, 255, 255); // ��ȫ��

    int no4StarCount = 0; // 4���� �������� �� ���� Ƚ��
    int no5StarCount = 0; // 5���� �������� �� ���� Ƚ��
    int gatchaCount = 0; // ���� ��í Ƚ��
    bool pickUpCount = false; // �Ⱦ�ĳ �Ծ����� �ȸԾ����� ���� Ȯ�� 

    double rate5Star; // 5�� Ȯ��
    double rate4Star; // 4�� Ȯ��
    double rate3Star; // 3�� Ȯ��
    double baserate5; // �⺻ 5�� Ȯ��
    double baserate4; // �⺻ 4�� Ȯ��
    double baserate3; // �⺻ 3�� Ȯ��

    float rollRandomValue; // ���� ��í ����
    int listRandomValue; // ��í ���̺� ����
    bool characterSuccess; // 4�� ĳ���� vs ���� ���� Ȯ�� (50�� 50) 
    bool pickUpSuccess; // 5�� �Ⱦ�ĳ vs �� ���� Ȯ�� (50�� 50) 

    // ��5 �Ⱦ� ĳ����
    List<string> featured5Characters = new List<string>
    {
        "����Ų"
    };

    // ��5 ĳ����
    List<string> star5Characters = new List<string>
    {
        "������", "��Ʈ", "��γ�", "���ĵ�", "Ŭ���", "����", "���"
    };

    // ��4 �Ⱦ� ĳ����
    List<string> featured4Characters = new List<string>
    {
        "�̻�", "����", "��Ÿ��"
    };

    // ��4 ĳ����
    List<string> star4Characters = new List<string>
    {
        "Mar. 7th", "����", "�Ƹ���", "�ƽ�Ÿ", "�츣Ÿ", "���", "����", "��ũ", "�һ�", "û��", "����", "���", "��ī",
        "����", "��׺�", "�Ѿ�", "����", "������", "����"
    };

    // ��4 ����
    List<string> star4LightCones = new List<string>
    {
        "���� ���� ��ȭ", "�� �λ�� ��� ��", "������ ù��", "ħ������", "��� �� ���",
        "�δ����İ� ȯ����", "�������� ź��", "���� ����", "��ɰ��� �ü�", "������ ����",
        "���", "�༺���� ����", "��� �ͼ�", "������ ������Ű�� ��", "�˸��� Ÿ�̹�",
        "�����ó�� ������ ���", "���� ���� ����", "�ȷο츦 ��Ź��!", "��! ��! ��!",
        "Ǫ�� �ϴ� �Ʒ�", "õ����� �޽�", "������ ���� ���", "�� ����� �ܼ�Ʈ",
        "������ ��", "��ȭ�� ħ���� ��", "�Ǿ�� ��ٸ��� ��", "�׸���ó�� �ڵ����� ��",
        "���� ��Ÿ��", "õ����� �Ⱥ� �λ�"
    };

    // ��3 ����
    List<string> star3LightCones = new List<string>
    {   
        "ȭ����", "ǳ��", "õ��", "�ڹ�", "����", "��â", "��ī�̺�", "������ ���� ȭ��",
        "���� ����", "������ �ູ", "����", "�ɿ��� ��", "�¹��� ���", "������ ����",
        "�븳", "����", "����", "���� ��ô", "���� �׸���", "��︲", "�İ�",
        "��Ÿ�� �׸���", "�߾� ȸ��"
    };  

    void Start()
    {
        UpdateGachaRates();
        UpdateText();
    }

    void UpdateGachaRates()
    {
        baserate5 = 0.006;
        baserate4 = 0.051;
        baserate3 = 0.943;

        if (no5StarCount >= 89)
            rate5Star = 1.0;
        else if (no5StarCount >= 74)
            rate5Star = baserate5 + 0.06 * (no5StarCount - 73);
        else
            rate5Star = baserate5;

        if (no4StarCount == 9)
        {
            rate4Star = 1.0 - rate5Star;
            rate3Star = 0.0;
        }
        else if (no4StarCount == 8)
        {
            double boostedRate4 = baserate4 + 0.51;
            double boostedRate3 = 1.0 - baserate5 - boostedRate4;

            rate4Star = (boostedRate4 / (boostedRate4 + boostedRate3)) * (1.0 - rate5Star);
            rate3Star = (boostedRate3 / (boostedRate4 + boostedRate3)) * (1.0 - rate5Star);
        }
        else
        {
            rate4Star = (baserate4 / (baserate4 + baserate3)) * (1.0 - rate5Star);
            rate3Star = (baserate3 / (baserate4 + baserate3)) * (1.0 - rate5Star);
        }
    }

    public (string resultText, int starGrade) GachaRoll()
    {
        rollRandomValue = Random.value;
        string resultMsg = "";
        int grade = 3;

        if (rollRandomValue <= rate5Star)
        {
            grade = 5;
            if (pickUpCount)
            {
                if (featured5Characters.Count > 0)
                {
                    listRandomValue = Random.Range(0, featured5Characters.Count);
                    resultMsg = "��5 �Ⱦ�!\n" + featured5Characters[listRandomValue];
                }
                pickUpCount = false;
            }
            else
            {
                pickUpSuccess = Random.value < 0.5f;
                if (pickUpSuccess && featured5Characters.Count > 0)
                {
                    listRandomValue = Random.Range(0, featured5Characters.Count);
                    resultMsg = "��5 �Ⱦ�!\n" + featured5Characters[listRandomValue];
                }
                else if (star5Characters.Count > 0)
                {
                    listRandomValue = Random.Range(0, star5Characters.Count);
                    resultMsg = "��5 �Ϲ�!\n" + star5Characters[listRandomValue];
                    pickUpCount = true;
                }
            }
            no4StarCount = 0;
            no5StarCount = 0;
        }
        else if (rollRandomValue <= rate5Star + rate4Star)
        {
            grade = 4;
            characterSuccess = Random.value < 0.5f;

            if (characterSuccess)
            {
                pickUpSuccess = Random.value < 0.5f;

                if (pickUpSuccess && featured4Characters.Count > 0)
                {
                    listRandomValue = Random.Range(0, featured4Characters.Count);
                    resultMsg = "��4 �Ⱦ�!\n" + featured4Characters[listRandomValue];
                }
                else if (star4Characters.Count > 0)
                {
                    listRandomValue = Random.Range(0, star4Characters.Count);
                    resultMsg = "��4 �Ϲ�!\n" + star4Characters[listRandomValue];
                }
            }
            else if (star4LightCones.Count > 0)
            {
                listRandomValue = Random.Range(0, star4LightCones.Count);
                resultMsg = "��4 ����!\n" + star4LightCones[listRandomValue];
            }

            no4StarCount = 0;
            no5StarCount++;
        }
        else
        {
            if (star3LightCones.Count > 0)
            {
                listRandomValue = Random.Range(0, star3LightCones.Count);
                resultMsg = "��3 ����!\n" + star3LightCones[listRandomValue];
            }

            no4StarCount++;
            no5StarCount++;
        }

        gatchaCount++;
        Debug.Log($"{gatchaCount}ȸ °, {resultMsg}");
        UpdateGachaRates(); 
        UpdateText();   

        return (resultMsg, grade);
    }
    public void GachaRoll_Single()
    {
        var result = GachaRoll();
        resultTextObjects[0].text = result.resultText;
        SetColor(resultBGObjects[0], result.starGrade);

        // ������ 9ĭ �ʱ�ȭ
        for (int i = 1; i < 10; i++)
        {
            resultTextObjects[i].text = "";
            resultBGObjects[i].color = Color.clear;
        }
    }

    public void GachaRoll_10()
    {
        for (int i = 0; i < 10; i++)
        {
            var result = GachaRoll();
            resultTextObjects[i].text = result.resultText;
            SetColor(resultBGObjects[i], result.starGrade);
        }
    }

    void SetColor(UnityEngine.UI.Image img, int grade)
    {
        img.color = grade switch
        {
            5 => star5Color,
            4 => star4Color,
            3 => star3Color,
            _ => Color.white
        };
    }

    public void UpdateText()
    {
        rate_Text.text = $"���� Ȯ��\r\n" +
                         $"5��: {(rate5Star * 100):F1}%\r\n" +
                         $"4��: {(rate4Star * 100):F1}%\r\n" +
                         $"3��: {(rate3Star * 100):F1}%\r\n";

        count_Text.text = $"��í {gatchaCount}ȸ";
    }
}