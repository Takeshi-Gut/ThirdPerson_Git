using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleJumper : MonoBehaviour
{
    // �W�����v�����Ƃ��̍ő�̍�����Float�^�̕ϐ��ō쐬�B�ϐ����͔C��
    private float jumpHight;

    // �W�����v���̎��Ԃ�Float�^�̕ϐ��ō쐬����B�ϐ����͔C��
    private float jumpTime;

    // �W�����v���邩��Bool�^�̕ϐ����쐬����B�ϐ����͔C��
    private bool isJump;



    // Update is called once per frame
    void Update()
    {
        // �����A�W�����v���邩��Bool�^�̕ϐ���false��
        // �Ȃ����A������transform.position��Y������0���傫��������
        if (isJump = false && this.transform.position.y > 0)
        {
            // Vector3�^�ŕϐ�fallingPos���쐬���A������transfrom.position��������
            Vector3 fallingPos = this.transform.position;

            // �ϐ�fallingPos.y��
            // Time.deltaTime�ɑ΂��ďd�͉����x���|�����l�����Z����
            fallingPos.y -= Time.deltaTime * Physics.gravity.y;

            // this.transfrom.position��Vector3�^�ŕϐ�fallingPos��������
            this.transform.position = fallingPos;
        }

        // �����A�L�[�{�[�h�̃X�y�[�X�L�[�������ꂽ��
        if (Input.GetKey(KeyCode.Space))
        {
            // �W�����v���邩��Bool�^�̕ϐ���true�ɑ������
            isJump = true;
        }



        // �����A�W�����v���邩��Bool�^�̕ϐ���true�������ꍇ

        // ������transfrom.position��Y������
        // �W�����v�����Ƃ��̍ő�̍�����Flaot�^�̕ϐ��̒l�ɂȂ�܂�
        // Vector3�^�ŕϐ�jumpingPos���쐬���A������transfrom.position��������B
        // �ϐ�jumpingPos.y��Time.deltaTime�����Z����
        // this.tramnsfrom.position��Vector3�^�ŕϐ�jumpingPos��������

        // �����A������transfrom.position��Y������
        // �W�����v�����Ƃ��̍ő�̍�����Float�^�̕ϐ��̒l�𒴂�����
        // �W�����v���邩��Bool�^�̕ϐ���false�ɑ������
    }
}
