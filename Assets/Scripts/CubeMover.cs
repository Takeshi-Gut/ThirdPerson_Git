using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    /// <summary>
    /// cubeの位置情報
    /// </summary>
    private Transform cubeTransform;

    /// <summary>
    /// 1秒を計測する変数
    /// </summary>
    private float timer = 1f;



    //public GameObject Cube;
    //float seconds = 0f;
    //public GameObject SphereBlue;
    //public GameObject SphereRed;

    /// <summary>
    /// 最初に1回だけ実行される
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        //cubeTransformに位置情報を代入
        cubeTransform = GetComponent<Transform>();


        // 自身の位置情報を取得
        //Transform myTransform = this.transform;
    }

    /// <summary>
    /// 毎フレーム実行される処理
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        // timerから毎フレームの差分を減らしていく
        timer -= Time.deltaTime;

        // もしtimerが0を下回ったら
        if (timer < 0)
        {
            // ランダムに0か1かを取得する
            var random = Random.Range(0, 2);

            // ランダムに取得された数値が0だったら
            if (random == 0)
            {
                // 一時的な変数にCubeのPositionを代入
                var nextPos = cubeTransform.position;

                // xに1を足す
                nextPos.x += 1;

                // cubeのPositionに一時変数を代入
                cubeTransform.position = nextPos;
            }

            else
            {
                // 一時的な変数にCubeのPositionを代入
                var nextPos = cubeTransform.position;

                // xに1を引く
                nextPos.x -= 1;
                // cubeのPositionに一時変数を代入
                cubeTransform.position = nextPos;
            }
            // timerの変数が０以下になっているので1を代入する
            timer = 1f;

        }

        ////X方向に移動する(右方向)
        ////transform.Translate(1.0f * Time.deltaTime, 0, 0);
        //transform.position += new Vector3 ( 1.0f, 0, 0 ) * Time.deltaTime;

        ////secondsに時間を代入
        //seconds += Time.deltaTime;

        //// Debug.Log ( seconds );


        ////もし経過時間が10秒を超えたら
        //if ( seconds >= 10.0f )
        //{
        //    //CUBEを非アクティブにする
        //    this.gameObject.SetActive ( false );
        //}


        ////SphereBlueの位置を取得
        //Vector3 sbPos = SphereBlue.transform.position;

        ////SphereRedの位置を取得
        //Vector3 srPos = SphereRed.transform.position;

        ////SphereBlueとSphereRedの距離を取得
        //float dis = Vector3.Distance ( sbPos, srPos );

        ////Debug.Logで距離をコメント
        //Debug.Log ("距離"+ dis );
    }
}
