using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    //public GameObject Cube;
    float seconds = 0f;
    public GameObject SphereBlue;
    public GameObject SphereRed;

    // Start is called before the first frame update
    void Start ( )
    {
        // 自身の位置情報を取得
        Transform myTransform = this.transform;
    }

    // Update is called once per frame
    void Update ( )
    {
        //X方向に移動する(右方向)
        //transform.Translate(1.0f * Time.deltaTime, 0, 0);
        transform.position += new Vector3 ( 1.0f, 0, 0 ) * Time.deltaTime;

        //secondsに時間を代入
        seconds += Time.deltaTime;

        // Debug.Log ( seconds );


        //もし経過時間が10秒を超えたら
        if ( seconds >= 10.0f )
        {
            //CUBEを非アクティブにする
            this.gameObject.SetActive ( false );
        }


        //SphereBlueの位置を取得
        Vector3 sbPos = SphereBlue.transform.position;

        //SphereRedの位置を取得
        Vector3 srPos = SphereRed.transform.position;

        //SphereBlueとSphereRedの距離を取得
        float dis = Vector3.Distance ( sbPos, srPos );

        //Debug.Logで距離をコメント
        Debug.Log ("距離"+ dis );
    }
}
