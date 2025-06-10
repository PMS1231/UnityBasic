using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GatchaSystem : MonoBehaviour
{
    // 가챠 횟수 및 확률 텍스트
    public TextMeshProUGUI count_Text;
    public TextMeshProUGUI rate_Text;

    // 가챠 결과 텍스트 
    public TextMeshProUGUI[] resultTextObjects;

    // 가챠 결과창 배경 
    public UnityEngine.UI.Image[] resultBGObjects;

    // 가챠 결과창 색깔
    Color star3Color = new Color32(79, 133, 255, 255);  // 파란색
    Color star4Color = new Color32(255, 218, 82, 255);  // 노란색
    Color star5Color = new Color32(255, 135, 255, 255); // 분홍색

    int no4StarCount = 0; // 4성이 연속으로 안 나온 횟수
    int no5StarCount = 0; // 5성이 연속으로 안 나온 횟수
    int gatchaCount = 0; // 누적 가챠 횟수
    bool pickUpCount = false; // 픽업캐 먹었는지 안먹었는지 여부 확인 

    double rate5Star; // 5성 확률
    double rate4Star; // 4성 확률
    double rate3Star; // 3성 확률
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
                    resultMsg = "★5 픽업!\n" + featured5Characters[listRandomValue];
                }
                pickUpCount = false;
            }
            else
            {
                pickUpSuccess = Random.value < 0.5f;
                if (pickUpSuccess && featured5Characters.Count > 0)
                {
                    listRandomValue = Random.Range(0, featured5Characters.Count);
                    resultMsg = "★5 픽업!\n" + featured5Characters[listRandomValue];
                }
                else if (star5Characters.Count > 0)
                {
                    listRandomValue = Random.Range(0, star5Characters.Count);
                    resultMsg = "★5 일반!\n" + star5Characters[listRandomValue];
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
                    resultMsg = "★4 픽업!\n" + featured4Characters[listRandomValue];
                }
                else if (star4Characters.Count > 0)
                {
                    listRandomValue = Random.Range(0, star4Characters.Count);
                    resultMsg = "★4 일반!\n" + star4Characters[listRandomValue];
                }
            }
            else if (star4LightCones.Count > 0)
            {
                listRandomValue = Random.Range(0, star4LightCones.Count);
                resultMsg = "★4 광추!\n" + star4LightCones[listRandomValue];
            }

            no4StarCount = 0;
            no5StarCount++;
        }
        else
        {
            if (star3LightCones.Count > 0)
            {
                listRandomValue = Random.Range(0, star3LightCones.Count);
                resultMsg = "★3 광추!\n" + star3LightCones[listRandomValue];
            }

            no4StarCount++;
            no5StarCount++;
        }

        gatchaCount++;
        Debug.Log($"{gatchaCount}회 째, {resultMsg}");
        UpdateGachaRates(); 
        UpdateText();   

        return (resultMsg, grade);
    }
    public void GachaRoll_Single()
    {
        var result = GachaRoll();
        resultTextObjects[0].text = result.resultText;
        SetColor(resultBGObjects[0], result.starGrade);

        // 나머지 9칸 초기화
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
        rate_Text.text = $"현재 확률\r\n" +
                         $"5성: {(rate5Star * 100):F1}%\r\n" +
                         $"4성: {(rate4Star * 100):F1}%\r\n" +
                         $"3성: {(rate3Star * 100):F1}%\r\n";

        count_Text.text = $"가챠 {gatchaCount}회";
    }
}