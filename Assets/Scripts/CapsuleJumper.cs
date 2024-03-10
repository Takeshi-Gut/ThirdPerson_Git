using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleJumper : MonoBehaviour
{
    // �W�����v�����Ƃ��̍ő�̍�����Float�^�̕ϐ��ō쐬�B�ϐ����͔C��
    private float jumpHight = 2f;

    // �W�����v���̎��Ԃ�Float�^�̕ϐ��ō쐬����B�ϐ����͔C��
    private float jumpTime = 1f;

    // �W�����v���邩��Bool�^�̕ϐ����쐬����B�ϐ����͔C��
    private bool isJump = false;



    // Update is called once per frame
    void Update()
    {
        // �����A�W�����v���邩��Bool�^�̕ϐ���false��
        // �Ȃ����A������transform.position��Y������0���傫��������
        if (!isJump && this.transform.position.y >= 0)
        {
            // Vector3�^�ŕϐ�fallingPos���쐬���A������transfrom.position��������
            Vector3 fallingPos = this.transform.position;

            // �ϐ�fallingPos.y��
            // Time.deltaTime�ɑ΂��ďd�͉����x���|�����l�����Z����
            fallingPos.y += Time.deltaTime * Physics.gravity.y;

            // this.transfrom.position��Vector3�^�ŕϐ�fallingPos��������
            this.transform.position = fallingPos;
        }

        // �����A�L�[�{�[�h�̃X�y�[�X�L�[�������ꂽ��
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // �W�����v���邩��Bool�^�̕ϐ���true�ɑ������
            isJump = true;
        }



        // �����A�W�����v���邩��Bool�^�̕ϐ���true�������ꍇ
        if (isJump)
        {
            // ������transfrom.position��Y������
            // �W�����v�����Ƃ��̍ő�̍�����Flaot�^�̕ϐ��̒l�ɂȂ�܂�
            // Vector3�^�ŕϐ�jumpingPos���쐬���A������transfrom.position��������B
            if (this.transform.position.y <= jumpHight)
            {
                Vector3 jumpingPos = this.transform.position;

                // �ϐ�jumpingPos.y��Time.deltaTime�����Z����
                // this.tramnsfrom.position��Vector3�^�ŕϐ�jumpingPos��������

                jumpingPos.y += Time.deltaTime;
                this.transform.position = jumpingPos;
            }


            // �����A������transfrom.position��Y������
            // �W�����v�����Ƃ��̍ő�̍�����Float�^�̕ϐ��̒l�𒴂�����
            // �W�����v���邩��Bool�^�̕ϐ���false�ɑ������
            if (this.transform.position.y >= jumpHight)
            {
                isJump = false;
            }
        }
    }
}
