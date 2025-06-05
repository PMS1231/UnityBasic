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
    string myName = "박민수";
    int age = 25;
    double height = 177.7;
    float weight = 77.7f;
    string nationality = "대한민국";
    string address = "김해";
    BloodType blood = BloodType.A;
    DateTime birthDate = new DateTime(2000, 5, 18); 
    List<string> hobbies = new List<string> { "게임", "음악" };
    bool maleGender = true;

    void Start()
    {
        SelfIntroduction();
    }
    void SelfIntroduction()
    {
        string hobbyStr = string.Join(", ", hobbies);

        Debug.Log($"안녕하세요, 제 이름은 {myName}입니다.");
        Debug.Log($"저는 {birthDate.ToLongDateString()}에 태어났고, 나이는 {age}살 입니다.");
        Debug.Log($"성별은 남자가 {maleGender}고, 혈액형은 {blood}형입니다.");
        Debug.Log($"키는 {height}cm, 몸무게는 {weight}kg입니다.");
        Debug.Log($"국적은 {nationality}, 현재 거주지는 {address}입니다.");
        Debug.Log($"취미는 {hobbyStr}입니다.");
    }


}
