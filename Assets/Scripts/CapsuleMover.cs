using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleMover : MonoBehaviour
{
    // 現在のPositionのVector3型変数currentPosを作成してください。
    private Vector3 currentPos;

    // 現在のPositionのVector3型変数nextPosを作成してください。
    private Vector3 nextPos;

    // 移動する際に使う時間を設定するfloat変数moveTimeを作成してください。
    private float moveTime;

    // 移動中のフラグを管理するbool型変数isMoveを作成してください。
    private bool isMove;


    // Update is called once per frame
    void Update()
    {
        // InputSystemを使う場合に、Wキーの押下を取得する
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            // 自分のポジションをz軸方向に+1を加算する
            //this.transform.position += Vector3.forward;

            // currentPosに現在の自分のpositionを代入する
            currentPos = this.transform.position;

            // nextPosに自分のpositionにZ軸+1の値を加算する
            nextPos += Vector3.forward;

            // moveTimeを0秒に代入する
            moveTime = 0f;

            // isMoveにtrueを代入する
            isMove = true;
        }

        // ①：Aキーの押下を取得し、Wキーの押下時の処理と同じようにnextPosにX軸-1の値を加算する
        if(Keyboard.current.aKey.wasPressedThisFrame)
        {
            // currentPosに現在の自分のpositionを代入する
            currentPos = this.transform.position;

            // nextPosに自分のpositionにX軸-1の値を加算する
            nextPos += Vector3.left;

            // moveTimeを0秒に代入する
            moveTime = 0f;

            // isMoveにtrueを代入する
            isMove = true;
        }


        // ②：Sキーの押下を取得し、Wキーの押下時の処理と同じようにnextPosにZ軸-1の値を加算する
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            // currentPosに現在の自分のpositionを代入する
            currentPos = this.transform.position;

            // nextPosに自分のpositionにZ軸-1の値を加算する
            nextPos += Vector3.back;

            // moveTimeを0秒に代入する
            moveTime = 0f;

            // isMoveにtrueを代入する
            isMove = true;
        }

        // ③：Dキーの押下を取得し、Wキーの押下時の処理と同じようにnextPosにX軸+1の値を加算する
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            // currentPosに現在の自分のpositionを代入する
            currentPos = this.transform.position;

            // nextPosに自分のpositionにX軸+1の値を加算する
            nextPos += Vector3.right;

            // moveTimeを0秒に代入する
            moveTime = 0f;

            // isMoveにtrueを代入する
            isMove = true;
        }


        // もし、isMoveがtrueなら
        if (isMove == true)
        {
            // moveTimeにTime.deltaTimeを足していく
            moveTime += Time.deltaTime;
        }

        // floatの変数でratio（率）を作成し、moveTimeを1で割った値を代入する
        float ratio = moveTime / 1;

        // 自分のpositionにVector3.Lerp(currentPos,nextPos,ratio)を代入する
        this.transform.position = Vector3.Lerp(currentPos, nextPos, ratio);

        // もし、ratioが1を超えたら
        if (ratio > 1)
        {
            // isMoveをfalseにする
            isMove = false;
        }



        //// ①:Aキーの押下を取得し、自分のポジションのx軸方向に対して-1を加算する
        //if (Keyboard.current.aKey.wasPressedThisFrame)
        //{
        //    this.transform.position += Vector3.left;
        //}
        //// ②:Sキーの押下を取得し、自分のポジションのz軸方向に対して-1を加算する
        //if (Keyboard.current.sKey.wasPressedThisFrame)
        //{
        //    this.transform.position += Vector3.back;
        //}
        //// ③:Dキーの押下を取得し、自分のポジションのx軸方向に対して+1を加算する
        //if (Keyboard.current.dKey.wasPressedThisFrame)
        //{
        //    this.transform.position += Vector3.right;
        //}


    }
}
