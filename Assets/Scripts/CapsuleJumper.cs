using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleJumper : MonoBehaviour
{
    // ジャンプしたときの最大の高さをFloat型の変数で作成。変数名は任意
    private float jumpHight;

    // ジャンプ中の時間をFloat型の変数で作成する。変数名は任意
    private float jumpTime;

    // ジャンプするかのBool型の変数を作成する。変数名は任意
    private bool isJump;



    // Update is called once per frame
    void Update()
    {
        // もし、ジャンプするかのBool型の変数がfalseで
        // なおかつ、自分のtransform.positionのY成分が0より大きかったら
        if (isJump && this.transform.position.y > 0)
        {
            // Vector3型で変数fallingPosを作成し、自分のtransfrom.positionを代入する
            Vector3 fallingPos = this.transform.position;

            // 変数fallingPos.yに
            // Time.deltaTimeに対して重力加速度を掛けた値を減算する
            fallingPos.y -= Time.deltaTime * Physics.gravity.y;

            // this.transfrom.positionにVector3型で変数fallingPosを代入する
            this.transform.position = Vector3.
        }

        // もし、キーボードのスペースキーが押されたら
        // ジャンプするかのBool型の変数をtrueに代入する

        // もし、ジャンプするかのBool型の変数がtrueだった場合

        // 自分のtransfrom.positionのY成分が
        // ジャンプしたときの最大の高さのFlaot型の変数の値になるまで
        // Vector3型で変数jumpingPosを作成し、自分のtransfrom.positionを代入する。
        // 変数jumpingPos.yにTime.deltaTimeを加算する
        // this.tramnsfrom.positionにVector3型で変数jumpingPosを代入する

        // もし、自分のtransfrom.positionのY成分が
        // ジャンプしたときの最大の高さのFloat型の変数の値を超えたら
        // ジャンプするかのBool型の変数をfalseに代入する
    }
}
