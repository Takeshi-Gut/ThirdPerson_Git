using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDistance : MonoBehaviour
{
    /// <summary>
    /// Unity�ォ��ݒ肷��ʂ̋���
    /// </summary>
    public Transform AnotherSphere;



    // Update is called once per frame
    void Update()
    {
        // UnityEngine�ň���Vector3��Distance���\�b�h���g�p����ƁA
        // �����ƕʂ̋��̂Ƃ̋������o��̂ŁA�����Debug.Log�ŏo�͂���
        Debug.Log(Vector3.Distance(this.transform.position, AnotherSphere.position));
    }
}
