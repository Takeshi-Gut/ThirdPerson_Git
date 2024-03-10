using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapYear : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // LeapYearJudge(2000)と書き、下のメソッドが正しく判定できているかを確認する
        LeapYearJudge(2000);

    }

    // public修飾子でvoid型のLeapYearJudgeというメソッドを作成してください。
    // 第一引数にint型のyearを指定してください。
    public void LeapYearJudge(int year)
    {
        // もし、yearが4で割り切れたらDebug.Logに"閏年"と出力してください。
        // そうじゃない場合はDebug.Logに"閏年じゃない"と出力します。
        if (year % 4 == 0)
        {
            // 100で割り切れて、400でも割り切れたらDebug.Logに"閏年"と出力してください。
            if (year % 100 == 0 && year % 400 == 0)
            {
                Debug.Log("閏年");
                // Debug.Logの下の行でreturnしてください。
                return;
            }

            // 100で割り切れたら閏年ではないのでDebug.Logに"閏年じゃない"と出力してください。
            if (year % 100 == 0)
            {
                Debug.Log("閏年じゃない");
                // Debug.Logの下の行でreturnしてください。
                return;
            }



            Debug.Log("閏年");
        }
        else
        {
            Debug.Log("閏年じゃない");
        }
    }
}
