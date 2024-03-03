using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorProgramming : MonoBehaviour
{

    /// <summary>
    /// Vector3型はx.y.zの成分を持つ構造体です。
    /// x.y.zは各々float型の値を持っています。
    /// </summary>
    private Vector3 currentPos;

    /// <summary>
    /// カメラの変数を作成する
    /// </summary>
    private Camera mainCamera;

    // 変数culcVector、zeroで初期化
    private Vector3 culcVector = Vector3.zero;



    // Start is called before the first frame update
    void Start()
    {
        // 計算をする場合、左辺と右辺は同じ型じゃないとエラーになります
        culcVector += Vector3.right;
        culcVector += Vector3.up;
        culcVector += Vector3.back;
        Debug.Log(culcVector);// (1.1.-1)


        // MainCameraのタグがついているカメラを取得する
        mainCamera = Camera.main;


        // currentPosに自分のposition(x,y,z)を代入する
        currentPos = this.transform.position;
        Debug.Log(currentPos);
        // vector3の中身であるx,y,zに対して、全ての要素に対する操作なら可能
        this.transform.position *= 2;

        // これはエラーになる
        // this.transform.position.x += 1;

        // エラーを回避する方法は下記
        Vector3 changePos = this.transform.position;
        changePos.x += 1;
        this.transform.position = changePos;

        // さて、この値はどう出力されるでしょうか
        int x = 5;// 実態
        // XChange(x);
        x = 10;
        Debug.Log(x);
    }
    private void XChange(int x)
    {
        x = 10;
    }

    /// <summary>
    /// vector3.zeroはVector3(0,0,0)です
    /// </summary>
    private Vector3 startPos = Vector3.zero;

    /// <summary>
    /// vector3.rightはVector3(1,0,0)です
    /// </summary>
    private Vector3 endPos = Vector3.right;

    /// <summary>
    /// 何秒で移動するかの時間幅
    /// </summary>
    private float duration = 1f;


    // Update is called once per frame
    void Update()
    {
        // 補間位置計算Time.timeはゲームが実行されてからの時間
        var time = Mathf.PingPong(Time.time / duration, 1);

        // 補間位置を反映
        transform.position = Vector3.Lerp(startPos, endPos, time);



        // LookAtメソッドを使うことにより、
        // 角度を引数のGameObjectのPositionに向けることができる
        mainCamera.transform.LookAt(this.transform.position);
    }
}
