using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringProgramming : MonoBehaviour
{
    /// <summary>
    /// string型の変数に代入するときは""で囲んだ中で代入できる
    /// </summary>
    private string userName = "花子";
    private string userAddress = "京都府";

    /// <summary>
    /// 文字列型変数の中身を空にしたければ、string.Emptyで代入する
    /// </summary>
    private string userPetName = string.Empty;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(userName + "さんは");

        Debug.Log(userAddress + "に住んでいる");

        // $"{}"で囲んだ{}の部分は文字列以外でも文字列として扱える
        Debug.Log($"{userName}さんのスコアは{123}点です");
    }
}
