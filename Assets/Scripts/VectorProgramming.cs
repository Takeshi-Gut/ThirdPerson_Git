using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorProgramming : MonoBehaviour
{

    /// <summary>
    /// Vector3�^��x.y.z�̐��������\���̂ł��B
    /// x.y.z�͊e�Xfloat�^�̒l�������Ă��܂��B
    /// </summary>
    private Vector3 currentPos;

    /// <summary>
    /// �J�����̕ϐ����쐬����
    /// </summary>
    private Camera mainCamera;

    // �ϐ�culcVector�Azero�ŏ�����
    private Vector3 culcVector = Vector3.zero;



    // Start is called before the first frame update
    void Start()
    {
        // �v�Z������ꍇ�A���ӂƉE�ӂ͓����^����Ȃ��ƃG���[�ɂȂ�܂�
        culcVector += Vector3.right;
        culcVector += Vector3.up;
        culcVector += Vector3.back;
        Debug.Log(culcVector);// (1.1.-1)


        // MainCamera�̃^�O�����Ă���J�������擾����
        mainCamera = Camera.main;


        // currentPos�Ɏ�����position(x,y,z)��������
        currentPos = this.transform.position;
        Debug.Log(currentPos);
        // vector3�̒��g�ł���x,y,z�ɑ΂��āA�S�Ă̗v�f�ɑ΂��鑀��Ȃ�\
        this.transform.position *= 2;

        // ����̓G���[�ɂȂ�
        // this.transform.position.x += 1;

        // �G���[�����������@�͉��L
        Vector3 changePos = this.transform.position;
        changePos.x += 1;
        this.transform.position = changePos;

        // ���āA���̒l�͂ǂ��o�͂����ł��傤��
        int x = 5;// ����
        // XChange(x);
        x = 10;
        Debug.Log(x);
    }
    private void XChange(int x)
    {
        x = 10;
    }

    /// <summary>
    /// vector3.zero��Vector3(0,0,0)�ł�
    /// </summary>
    private Vector3 startPos = Vector3.zero;

    /// <summary>
    /// vector3.right��Vector3(1,0,0)�ł�
    /// </summary>
    private Vector3 endPos = Vector3.right;

    /// <summary>
    /// ���b�ňړ����邩�̎��ԕ�
    /// </summary>
    private float duration = 1f;


    // Update is called once per frame
    void Update()
    {
        // ��Ԉʒu�v�ZTime.time�̓Q�[�������s����Ă���̎���
        var time = Mathf.PingPong(Time.time / duration, 1);

        // ��Ԉʒu�𔽉f
        transform.position = Vector3.Lerp(startPos, endPos, time);



        // LookAt���\�b�h���g�����Ƃɂ��A
        // �p�x��������GameObject��Position�Ɍ����邱�Ƃ��ł���
        mainCamera.transform.LookAt(this.transform.position);
    }
}
