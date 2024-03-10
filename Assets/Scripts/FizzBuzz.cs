using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FizzBuzz : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // FizzBuzzJudge()を書き、FizzかBuzzを判定してください。
        FizzBuzzJudge(15);
    }

    // public修飾子でvoid型のメソッドFizzBuzzJudge(int num)というメソッドを作ってください。
    // void型は（引数）のみ。戻り値、返り値はない。
    // 第一引数にint型のnumを指定してください。
    public void FizzBuzzJudge(int num)
    {
        // numが3と5の両方で割り切れるときは「FizzBuzz」をDebug.Logに出力してください。
        // ※複数の比較対象がある場合は、if文の順番は上に書き、return;でふるいにかける。
        if (num % 3 == 0 && num % 5 == 0)
        {
            Debug.Log("FizzBuzz");
            return;
        }

        // もし、numが3で割り切れるときは「Fizz」をDebug.Logに出力してください。
        if (num % 3 == 0)
        {
            Debug.Log("Fizz");
            return;
        }

        // もし、numが5で割り切れるときは「Buzz」をDebug.Logに出力してください。
        if (num % 5 == 0)
        {
            Debug.Log("Buzz");
            return;
        }

        else
        {
            Debug.Log("3でも5でも割り切れない");
        }
    }
}
