using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTemplate : MonoBehaviour
{
    // ①最初に変数を宣言する
    private int num = 0;


    // ②Unityで実行される処理を書いていく
    // 最初に1回だけスクリプトを実行する場合に書く場所
    // Start is called before the first frame update
    void Start()
    {
        num = 5;
        Debug.Log($"numを{num}で初期化する");
    }

    // フレーム毎に処理を実行する場合に書く場所
    // Update is called once per frame
    void Update()
    {
        // numに毎フレームで1を足していく
        num++;

        // numの値を判定してもらう
        numJudge(num);
    }

    // ③処理のメソッドを書いていく（実行するにはStartやUpDateの中で呼び出さないといけない）
    public void numJudge(int num)
    {
        // もし、引数のnumが100を超えたら
        if (num > 100)
        {
            // 100以上の処理をしない
            return;
        }
        // もし、引数のnumが50未満だったら
        if (num < 50)
        {
            Debug.Log($"{num}は50未満");

        }
        // 上のif文の判定以外だったら
        else
        {
            Debug.Log($"{num}は50以上");
        }
    }
}
