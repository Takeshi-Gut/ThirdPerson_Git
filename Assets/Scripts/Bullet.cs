using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // private修飾子でTransform型のrootTransformを作成してください。
    private Transform rootTransform;

    // private修飾子でbool型のinitializedという変数を作成してください。
    private bool initialized;

    // public修飾子のvoid型でBulletInitializeというメソッドを作成してください。
    // メソッドの第一引数にTransform型でshooterTransformを指定してください。

    public void BulletInitialize(Transform shooterTransform)
    {
        // rootTransformに第一引数に指定したshooterTransformを代入してください。
        // Initializedのフラグをtrueにします。
        rootTransform = shooterTransform;
        initialized = true;
    }


    // Update is called once per frame
    void Update()
    {
        // もし、initializedのフラグがtrueなら
        if (initialized)
        {
            // 新しくVector3型の変数Velocityを作成し、rootTransformのforwardを代入します。
            Vector3 Velocity = rootTransform.forward;

            // 自分のTransformのpositionにvelocityとTime.deltaTimeを掛けた値を加算する
            transform.position += Velocity * Time.deltaTime;
        }
    }
}
