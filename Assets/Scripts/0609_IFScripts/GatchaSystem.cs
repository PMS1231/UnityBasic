using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GatchaSystem : MonoBehaviour
{
    public TextMeshProUGUI count_Text;
    public TextMeshProUGUI rate_Text;

    int no4StarCount = 0; // 4성이 연속으로 안 나온 횟수
    int no5StarCount = 0; // 5성이 연속으로 안 나온 횟수
    int gatchaCount = 0; // 누적 가챠 횟수
    bool pickUpCount = false; // 픽업캐 먹었는지 안먹었는지 여부 확인 


    double rate3Star; // 3성 확률
    double rate4Star; // 4성 확률
    double rate5Star; // 5성 확률
    double baserate5; // 기본 5성 확률
    double baserate4; // 기본 4성 확률
    double baserate3; // 기본 3성 확률

    float rollRandomValue; // 랜덤 가챠 난수
    int listRandomValue; // 가챠 테이블 랜덤
    bool characterSuccess; // 4성 캐릭터 vs 광추 여부 확인 (50대 50) 
    bool pickUpSuccess; // 5성 픽업캐 vs 외 여부 확인 (50대 50) 

    // ★5 픽업 캐릭터
    List<string> featured5Characters = new List<string>
    {
        "히아킨"
    };

    // ★5 캐릭터
    List<string> star5Characters = new List<string>
    {
        "히메코", "웰트", "브로냐", "게파드", "클라라", "연경", "백로"
    };

    // ★4 픽업 캐릭터
    List<string> featured4Characters = new List<string>
    {
        "미샤", "서벌", "나타샤"
    };

    // ★4 캐릭터
    List<string> star4Characters = new List<string>
    {
        "Mar. 7th", "단항", "아를란", "아스타", "헤르타", "페라", "삼포", "후크", "소상", "청작", "정운", "어공", "루카",
        "링스", "계네빈", "한아", "설의", "갤러거", "맥택"
    };

    // ★4 광추
    List<string> star4LightCones = new List<string>
    {
        "수술 후의 대화", "밤 인사와 잠든 얼굴", "여생의 첫날", "침묵만이", "기억 속 모습",
        "두더지파가 환영해", "「나」의 탄생", "같은 심정", "사냥감의 시선", "랜도의 선택",
        "논검", "행성과의 만남", "비밀 맹세", "세상을 진정시키지 마", "알맞은 타이밍",
        "땀방울처럼 빛나는 결심", "우주 시장 동향", "팔로우를 부탁해!", "댄스! 댄스! 댄스!",
        "푸른 하늘 아래", "천재들의 휴식", "마음에 새긴 약속", "두 사람의 콘서트",
        "끝없는 춤", "조화가 침묵한 후", "피어나길 기다리는 꽃", "그림자처럼 뒤따르는 밤",
        "꿈의 몽타주", "천재들의 안부 인사"
    };

    // ★3 광추
    List<string> star3LightCones = new List<string>
    {   
        "화살촉", "풍작", "천경", "앰버", "그윽", "합창", "아카이브", "시위를 떠난 화살",
        "알찬 열매", "무너진 행복", "수비", "심연의 고리", "맞물린 톱니", "영험한 열쇠",
        "대립", "증식", "전멸", "강토 개척", "숨은 그림자", "어울림", "식견",
        "불타는 그림자", "추억 회상"
    };  

    void Start()
    {
        UpdateGachaRates();
        UpdateText();
    }

    void UpdateGachaRates()
    {
        // 기본 확률 고정
        baserate5 = 0.006; // 0.6%
        baserate4 = 0.051; // 5.1%
        baserate3 = 0.943; // 94.3%

        // 5성 확률 변동
        if (no5StarCount >= 89) // 가챠 90회시 100%
            rate5Star = 1.0;
        else if (no5StarCount >= 74)
            rate5Star = baserate5 + 0.06 * (no5StarCount - 73); // 74회부터 확률 +6%
        else
            rate5Star = baserate5;

        // 4성 및 3성 확률 변동
        if (no4StarCount == 9)
        {
            rate4Star = 1.0 - rate5Star; 
            rate3Star = 0.0;
        }
        else if (no4StarCount == 8)
        {
            // 하드코딩 (개선 필요)
            rate4Star = 0.561 * (1.0 - rate5Star);
            rate3Star = 0.439 * (1.0 - rate5Star);
        }
        else
        {
            // 평소 기본 비율
            rate4Star = (baserate4 / (baserate3 + baserate4)) * (1.0 - rate5Star);
            rate3Star = (baserate3 / (baserate3 + baserate4)) * (1.0 - rate5Star);
        }
    }

    public void GachaRoll()
    {
        rollRandomValue = Random.value;

        if (rollRandomValue <= rate5Star)
        {
            if (pickUpCount)
            {
                listRandomValue = Random.Range(0, featured5Characters.Count);
                Debug.Log("5성 픽업 캐릭터 출현! " + featured5Characters[listRandomValue] + " 등장!");
                pickUpCount = false;
            }
            else
            {
                pickUpSuccess = Random.value < 0.5f;

                if (pickUpSuccess)
                {
                    listRandomValue = Random.Range(0, featured5Characters.Count);
                    Debug.Log("5성 픽업 캐릭터 출현! " + featured5Characters[listRandomValue] + " 등장!");
                }
                else
                {
                    listRandomValue = Random.Range(0, star5Characters.Count);
                    Debug.Log("5성 캐릭터 출현! " + star5Characters[listRandomValue] + " 등장!");
                    pickUpCount = true;
                }
            }

            no5StarCount = 0;
        }
        else if (rollRandomValue <= rate5Star + rate4Star)
        {
            characterSuccess = Random.value < 0.5f;

            if (characterSuccess)
            {
                pickUpSuccess = Random.value < 0.5f;

                if (pickUpSuccess)
                {
                    listRandomValue = Random.Range(0, featured4Characters.Count);
                    Debug.Log("4성 픽업 캐릭터 출현! " + featured4Characters[listRandomValue] + " 등장!");
                }
                else
                {
                    listRandomValue = Random.Range(0, star4Characters.Count);
                    Debug.Log("4성 캐릭터 출현! " + star4Characters[listRandomValue] + " 등장!");
                }
            }
            else
            {
                listRandomValue = Random.Range(0, star4LightCones.Count);
                Debug.Log("4성 광추 출현! " + star4LightCones[listRandomValue] + " 등장!");
            }
            no4StarCount = 0;
        }
        else
        {
            listRandomValue = Random.Range(0, star3LightCones.Count);
            Debug.Log("3성 광추 출현! " + star3LightCones[listRandomValue] + " 등장!");
            no4StarCount++;
            no5StarCount++;
        }

        gatchaCount++;

        UpdateText();
        UpdateGachaRates();

    }

    public void GachaRoll_10()
    {
        for (int i = 0; i < 10; i++)
        {
            GachaRoll();
        }
    }

    public void UpdateText()
    {
        count_Text.text = $"가챠 {gatchaCount}회";
        rate_Text.text = $"현재 확률\r\n" +
                         $"5성: {(rate5Star * 100):F1}%\r\n" +
                         $"4성: {(rate4Star * 100):F1}%\r\n" +
                         $"3성: {(rate3Star * 100):F1}%\r\n";
    }
}
