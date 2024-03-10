using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // private�C���q��Transform�^��rootTransform���쐬���Ă��������B
    private Transform rootTransform;

    // private�C���q��bool�^��initialized�Ƃ����ϐ����쐬���Ă��������B
    private bool initialized;

    // public�C���q��void�^��BulletInitialize�Ƃ������\�b�h���쐬���Ă��������B
    // ���\�b�h�̑�������Transform�^��shooterTransform���w�肵�Ă��������B

    public void BulletInitialize(Transform shooterTransform)
    {
        // rootTransform�ɑ������Ɏw�肵��shooterTransform�������Ă��������B
        // Initialized�̃t���O��true�ɂ��܂��B
        rootTransform = shooterTransform;
        initialized = true;
    }


    // Update is called once per frame
    void Update()
    {
        // �����Ainitialized�̃t���O��true�Ȃ�
        if (initialized)
        {
            // �V����Vector3�^�̕ϐ�Velocity���쐬���ArootTransform��forward�������܂��B
            Vector3 Velocity = rootTransform.forward;

            // ������Transform��position��velocity��Time.deltaTime���|�����l�����Z����
            transform.position += Velocity * Time.deltaTime;
        }
    }
}
