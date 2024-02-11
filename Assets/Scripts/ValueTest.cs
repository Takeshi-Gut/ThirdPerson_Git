using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueTest : MonoBehaviour
{
    public string StartText = "スタート";

    /// <summary>
    /// 小数点がついてない数はintで宣言します
    /// </summary>
    private int age = 0; // privateなので頭文字は小文字

    /// <summary>
    /// 小数点がついている数はfloatで宣言します
    /// </summary>
    private const float taxRate = 1.1f;

    /// <summary>
    /// 大正の始まった年
    /// </summary>
    private const int Taisho = 1912;

    /// <summary>
    /// 昭和の始まった年
    /// </summary>
    private const int Showa = 1926;

    /// <summary>
    ///  平成の始まった年
    /// </summary>
    private const int Heisei = 1989;

    /// <summary>
    /// 令和の始まった年
    /// </summary>
    private const int Reiwa = 2019;



    // 最初に１回だけ実行されるメソッド（処理）
    //ゲームの初期化などに使う
    void Start()
    {
        //定数とは変数とは違い、宣言後に変えることができない
        //Reiwa = 2020; // スタートの中でもエラーになります

        // ageに20を代入する
        age = 20;

        // ageに21を代入する
        // age = 21;

        // 演算子
        age -= 1;
        // 意味はこれと一緒です。
        // age = 20-1;

        age += 1;
        // age = 20 + 1;

        age *= 2;
        // age = 20 * 2;

        age /= 2;
        // age = 20/2;

        age %= 2;
        // 余剰なので右辺で割ったあまりをだしてくれます。


        //ifはもし～だったら、
        // という条件でブロックの中の処理をするかどうかを設定することができます。
        // 21などだったら処理は通りません。
        if (age == 20)
        {
            Debug.Log(age);
        }

        // 演習：ageに23を代入する
        age = 23;
        // Debug.Logの小かっこの中で2024-ageを行う
        Debug.Log(2024 - age);

        // 演習：ageに56を代入する
        age = 56;
        // Debug.Logの小かっこの中で2024-ageを行なう。
        Debug.Log(2024 - age);

        // 新しくint型でplayerAgeの変数を作成し、任意の数で代入する。
        int playerAge = 100;

        // playerAgeの値を判定し、
        // 昭和生まれ（1926より前）、
        // 平成生まれ（1988より後）、
        // 令和生まれ（2019より後）、
        // 大正生まれ（1926より前）、
        // というDebug.Logを出す


        int bornAge = 2024 - playerAge; // playerAgeが100として1924


        // bornAgeが1924だとしたら
        if (bornAge >= Taisho && bornAge < Showa)
        {
            // ココは通る
            Debug.Log("大正生まれ");
        }

        if (bornAge >= Showa && bornAge <= Heisei)
        {
            Debug.Log("昭和生まれ");
        }

        if (bornAge > Heisei && bornAge < Reiwa)
        {
            Debug.Log("平成生まれ");
        }

        if (bornAge >= Reiwa)
        {
            Debug.Log("令和生まれ");
        }



        float value = 1000;
        value *= taxRate; // 左辺と右辺の型は揃えないといけない！
        Debug.Log(value);

        Debug.Log(StartText);


        // SUM関数を今から作ります。
        // (値1,値2)のシンプルなSUM関数を作ります
        // 例えばエクセルだと　=SUM(10,10)とセルに打ち込むと20が返ってきます
        Debug.Log(SUM(10, 10)); // Debug.Logで20と表示される

        // エクセルでいうところのAverage関数を作ってみてください
        // (値1,値2)のシンプルなAVERAGE関数
        Debug.Log(AVERAGE(50, 30)); // Degug.Logで40と出る

        Debug.Log($"Average:{AVERAGE(10f, 9f)}");

        // 引数を3つにすると。。。
        Debug.Log($"Average:{AVERAGE(10f, 9f,5f)}");
    }

    public int SUM(int value1, int value2) // カッコ内が引数という
    {
        return value1 + value2;
    }

    /// <summary>
    /// int型の平均を出してくれるので、小数点が無視されてしまう。。。
    /// </summary>
    public int AVERAGE(int value1, int value2)// カッコ内が引数(ひきすう)という
    {
        return (value1 + value2) / 2;
    }

    /// <summary>
    /// float型の平均を出してくれる。
    /// </summary>
    public float AVERAGE(float value1, float value2)// カッコ内が引数(ひきすう)という
    {
        return (value1 + value2) / 2;
    }

    // 引数の数が3つのAverage関数を作成してください。
    // 引数は（値1,値2,値3）のことです
    public float AVERAGE(float value1, float value2, float value3)
    {
        return (value1 + value2 + value3) / 3; // 戻り値、返り値
    }

    public float SUM(float value1 ,float value2 ,float value3)
    {
        return value1 + value2 + value3;　// 足し算、合計
    }





    // １秒間に指定されたフレーム分、実行される
    void Update()
    {
        // コメントアウトすると処理がされなくなります
        //Debug.Log("実行中");
    }
}
