using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfInfroduction : MonoBehaviour
{
    enum BloodType
    {
        A,
        B,
        O,
        AB
    }
    string myName = "�ڹμ�";
    int age = 25;
    double height = 177.7;
    float weight = 77.7f;
    string nationality = "���ѹα�";
    string address = "����";
    BloodType blood = BloodType.A;
    DateTime birthDate = new DateTime(2000, 5, 18); 
    List<string> hobbies = new List<string> { "����", "����" };
    bool maleGender = true;

    void Start()
    {
        SelfIntroduction();
    }
    void SelfIntroduction()
    {
        string hobbyStr = string.Join(", ", hobbies);

        Debug.Log($"�ȳ��ϼ���, �� �̸��� {myName}�Դϴ�.");
        Debug.Log($"���� {birthDate.ToLongDateString()}�� �¾��, ���̴� {age}�� �Դϴ�.");
        Debug.Log($"������ ���ڰ� {maleGender}��, �������� {blood}���Դϴ�.");
        Debug.Log($"Ű�� {height}cm, �����Դ� {weight}kg�Դϴ�.");
        Debug.Log($"������ {nationality}, ���� �������� {address}�Դϴ�.");
        Debug.Log($"��̴� {hobbyStr}�Դϴ�.");
    }


}
