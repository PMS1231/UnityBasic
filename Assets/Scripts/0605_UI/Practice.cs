using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Practice : MonoBehaviour
{
    void OnEnable()
    {
        Random.InitState(2);
        Debug.Log(Random.Range(1, 100));
        // 1 이상 100 미만의 랜덤한 값을 만들겠다.
    }
}
