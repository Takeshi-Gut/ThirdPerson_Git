using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    /// <summary>
    /// cube�̈ʒu���
    /// </summary>
    private Transform cubeTransform;

    /// <summary>
    /// 1�b���v������ϐ�
    /// </summary>
    private float timer = 1f;



    //public GameObject Cube;
    //float seconds = 0f;
    //public GameObject SphereBlue;
    //public GameObject SphereRed;

    /// <summary>
    /// �ŏ���1�񂾂����s�����
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        //cubeTransform�Ɉʒu������
        cubeTransform = GetComponent<Transform>();


        // ���g�̈ʒu�����擾
        //Transform myTransform = this.transform;
    }

    /// <summary>
    /// ���t���[�����s����鏈��
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        // timer���疈�t���[���̍��������炵�Ă���
        timer -= Time.deltaTime;

        // ����timer��0�����������
        if (timer < 0)
        {
            // �����_����0��1�����擾����
            var random = Random.Range(0, 2);

            // �����_���Ɏ擾���ꂽ���l��0��������
            if (random == 0)
            {
                // �ꎞ�I�ȕϐ���Cube��Position����
                var nextPos = cubeTransform.position;

                // x��1�𑫂�
                nextPos.x += 1;

                // cube��Position�Ɉꎞ�ϐ�����
                cubeTransform.position = nextPos;
            }

            else
            {
                // �ꎞ�I�ȕϐ���Cube��Position����
                var nextPos = cubeTransform.position;

                // x��1������
                nextPos.x -= 1;
                // cube��Position�Ɉꎞ�ϐ�����
                cubeTransform.position = nextPos;
            }
            // timer�̕ϐ����O�ȉ��ɂȂ��Ă���̂�1��������
            timer = 1f;

        }

        ////X�����Ɉړ�����(�E����)
        ////transform.Translate(1.0f * Time.deltaTime, 0, 0);
        //transform.position += new Vector3 ( 1.0f, 0, 0 ) * Time.deltaTime;

        ////seconds�Ɏ��Ԃ���
        //seconds += Time.deltaTime;

        //// Debug.Log ( seconds );


        ////�����o�ߎ��Ԃ�10�b�𒴂�����
        //if ( seconds >= 10.0f )
        //{
        //    //CUBE���A�N�e�B�u�ɂ���
        //    this.gameObject.SetActive ( false );
        //}


        ////SphereBlue�̈ʒu���擾
        //Vector3 sbPos = SphereBlue.transform.position;

        ////SphereRed�̈ʒu���擾
        //Vector3 srPos = SphereRed.transform.position;

        ////SphereBlue��SphereRed�̋������擾
        //float dis = Vector3.Distance ( sbPos, srPos );

        ////Debug.Log�ŋ������R�����g
        //Debug.Log ("����"+ dis );
    }
}
