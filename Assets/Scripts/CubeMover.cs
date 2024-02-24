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
        // ���g�̈ʒu�����擾
        Transform myTransform = this.transform;
    }

    // Update is called once per frame
    void Update ( )
    {
        //X�����Ɉړ�����(�E����)
        //transform.Translate(1.0f * Time.deltaTime, 0, 0);
        transform.position += new Vector3 ( 1.0f, 0, 0 ) * Time.deltaTime;

        //seconds�Ɏ��Ԃ���
        seconds += Time.deltaTime;

        // Debug.Log ( seconds );


        //�����o�ߎ��Ԃ�10�b�𒴂�����
        if ( seconds >= 10.0f )
        {
            //CUBE���A�N�e�B�u�ɂ���
            this.gameObject.SetActive ( false );
        }


        //SphereBlue�̈ʒu���擾
        Vector3 sbPos = SphereBlue.transform.position;

        //SphereRed�̈ʒu���擾
        Vector3 srPos = SphereRed.transform.position;

        //SphereBlue��SphereRed�̋������擾
        float dis = Vector3.Distance ( sbPos, srPos );

        //Debug.Log�ŋ������R�����g
        Debug.Log ("����"+ dis );
    }
}
