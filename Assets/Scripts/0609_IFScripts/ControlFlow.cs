using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class IF_GatchaSystem
{
    private int count = 0;
    public void Roll()
    {
        int result = Random.Range(1, 101);

        if (count >= 9)
        {
            Debug.Log("õ�� �޼�! ��û ȹ��!");
            count = 0;
        }
        else if (result <= 10)
            Debug.Log("10% Ȯ���� ��û�� �̾Ҵ�!");
        else if (result <= 30)
            Debug.Log("20% Ȯ���� �𳪸� �̾Ҵ�!");
        else
            Debug.Log("70% Ȯ���� ġġ�� �̾Ҵ�!");

        count++;
        Debug.Log($"{count}�� ��!");
    }
}
public class Switch_GatchaSystem
{
    private int randomValue = Random.Range(1, 101);
    public void GachaSwitch()
    {
        int selectNumb = 0;

        switch (selectNumb) //0
        {
            case 0:
                // ���� �Ӹ� ĳ���Ͱ� ���´�
                {
                    if (randomValue <= 10) // 1 ~ 10 -> 10%
                    {
                        // �Ⱦ� ĳ�� : �̹� �̱⿡ Ȯ���� ����  �����Ǵ� ĳ����
                        // �������� Ư�� ĳ���͸� ��ǥ�ϰ� �̰� ����� �ý���
                        Debug.Log("'���� �Ӹ�'�� �̾Ҵ�!");
                    }
                    else if (randomValue <= 30) // 11 ~ 30
                    {
                        Debug.Log("'��'�� �̾Ҵ�!");
                    }
                    else
                    {
                        Debug.Log("'ġġ'�� �̾ƹ��ȴ�!");
                    }
                }
                break;

            case 1:
                // �Ķ� �Ӹ� ĳ���Ͱ� ���´�
                {
                    if (randomValue <= 10) // 1 ~ 10 -> 10%
                    {
                        Debug.Log("'�Ķ� �Ӹ�'�� �̾Ҵ�!");
                    }
                    else if (randomValue <= 30) // 11 ~ 30
                    {
                        Debug.Log("'��'�� �̾Ҵ�!");
                    }
                    else
                    {
                        Debug.Log("'ġġ'�� �̾ƹ��ȴ�!");
                    }
                }
                break;

            case 2:
                // ��ȫ �Ӹ� ĳ���Ͱ� ���´�
                {
                    if (randomValue <= 10) // 1 ~ 10 -> 10%
                    {
                        Debug.Log("'��ȫ �Ӹ�'�� �̾Ҵ�!");
                    }
                    else if (randomValue <= 30) // 11 ~ 30
                    {
                        Debug.Log("'��'�� �̾Ҵ�!");
                    }
                    else
                    {
                        Debug.Log("'ġġ'�� �̾ƹ��ȴ�!");
                    }
                }
                break;

            default:
                // �Ķ� �Ӹ� ���� ĳ���Ͱ� ���´�.
                {
                    if (randomValue <= 10) // 1 ~ 10 -> 10%
                    {
                        Debug.Log("'�Ķ� �Ӹ� ����'�� �̾Ҵ�!");
                    }
                    else if (randomValue <= 30) // 11 ~ 30
                    {
                        Debug.Log("'��'�� �̾Ҵ�!");
                    }
                    else
                    {
                        Debug.Log("'ġġ'�� �̾ƹ��ȴ�!");
                    }
                }
                break;
        }
    }
}

public class ControlFlow : MonoBehaviour
{

    public TextMeshProUGUI Txt_Bumin;

    string[] character = { "������", "���ѳ�", "�ռ���", "����ȣ", "������", "������", "������", "������" };
    List<string> characterList = new List<string>();

    public void ArrayGacha() // character.Length
    {
        int randomValue = Random.Range(0, character.Length); // 8 , 0 ~ 7

        Debug.Log("������? " + character[randomValue] + "�� �����ϴ�.");
        Txt_Bumin.text = "������? " + character[randomValue] + "�� �����ϴ�.";
    }

    public void ListGacha() // characterList.Count
    {
        int randomValue = Random.Range(0, characterList.Count);  // 8 , 0 ~ 7
        Txt_Bumin.text = "������? " + characterList[randomValue] + "�� �����ϴ�.";
    }

    public void AddList()
    {
        // character �迭���� ��� �̸��� �ֽ��ϴ�.
        // characterList���� �ƹ� �����͵� �����ϴ�.

        // character �迭�� �����͸� charcterList���ٰ� �־��ִ� ���� �����ô�.
        // �츮�� ��� �ݺ����� ����ؼ� ����� ���ô�.

        for (int i = 0; i < character.Length; i++) // i < 8 -> 0 ~ 7
        {
            characterList.Add(character[i]);
        }

        for (int i = 0; i < characterList.Count; i++)
        {
            Debug.Log(characterList[i]);
        }
    }

    IF_GatchaSystem gatcha = new IF_GatchaSystem();
    public void OnClickRoll()
    {
        gatcha.Roll();
    }
    public void ForOnClickRoll()
    {
        Debug.Log("For 10���� �ߵ�!");

        for (int i = 0; i <10; i++)
        {
            gatcha.Roll();
        }
    }
    public void WhileOnClickRoll()
    {
        Debug.Log("While 10���� �ߵ�!");
        int count = 0 ;
        while (count<10)
        {
            gatcha.Roll();
            count++;
        }
    }

}

