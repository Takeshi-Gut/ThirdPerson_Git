using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 自身の位置情報を取得
        Transform myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {

        //X方向に移動する(右方向)
        //transform.Translate(1.0f * Time.deltaTime, 0, 0);
        transform.position += new Vector3(1.0f , 0,0) * Time.deltaTime;

    }
}
