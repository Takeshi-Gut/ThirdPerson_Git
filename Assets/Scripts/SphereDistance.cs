using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDistance : MonoBehaviour
{
    /// <summary>
    /// Unity上から設定する別の球体
    /// </summary>
    public Transform AnotherSphere;



    // Update is called once per frame
    void Update()
    {
        // UnityEngineで扱うVector3のDistanceメソッドを使用すると、
        // 自分と別の球体との距離が出るので、それをDebug.Logで出力する
        Debug.Log(Vector3.Distance(this.transform.position, AnotherSphere.position));
    }
}
