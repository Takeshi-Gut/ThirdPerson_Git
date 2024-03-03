using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleMover : MonoBehaviour
{
    // ���݂�Position��Vector3�^�ϐ�currentPos���쐬���Ă��������B
    private Vector3 currentPos;

    // ���݂�Position��Vector3�^�ϐ�nextPos���쐬���Ă��������B
    private Vector3 nextPos;

    // �ړ�����ۂɎg�����Ԃ�ݒ肷��float�ϐ�moveTime���쐬���Ă��������B
    private float moveTime;

    // �ړ����̃t���O���Ǘ�����bool�^�ϐ�isMove���쐬���Ă��������B
    private bool isMove;


    // Update is called once per frame
    void Update()
    {
        // InputSystem���g���ꍇ�ɁAW�L�[�̉������擾����
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            // �����̃|�W�V������z��������+1�����Z����
            //this.transform.position += Vector3.forward;

            // currentPos�Ɍ��݂̎�����position��������
            currentPos = this.transform.position;

            // nextPos�Ɏ�����position��Z��+1�̒l�����Z����
            nextPos += Vector3.forward;

            // moveTime��0�b�ɑ������
            moveTime = 0f;

            // isMove��true��������
            isMove = true;
        }

        // �@�FA�L�[�̉������擾���AW�L�[�̉������̏����Ɠ����悤��nextPos��X��-1�̒l�����Z����
        if(Keyboard.current.aKey.wasPressedThisFrame)
        {
            // currentPos�Ɍ��݂̎�����position��������
            currentPos = this.transform.position;

            // nextPos�Ɏ�����position��X��-1�̒l�����Z����
            nextPos += Vector3.left;

            // moveTime��0�b�ɑ������
            moveTime = 0f;

            // isMove��true��������
            isMove = true;
        }


        // �A�FS�L�[�̉������擾���AW�L�[�̉������̏����Ɠ����悤��nextPos��Z��-1�̒l�����Z����
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            // currentPos�Ɍ��݂̎�����position��������
            currentPos = this.transform.position;

            // nextPos�Ɏ�����position��Z��-1�̒l�����Z����
            nextPos += Vector3.back;

            // moveTime��0�b�ɑ������
            moveTime = 0f;

            // isMove��true��������
            isMove = true;
        }

        // �B�FD�L�[�̉������擾���AW�L�[�̉������̏����Ɠ����悤��nextPos��X��+1�̒l�����Z����
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            // currentPos�Ɍ��݂̎�����position��������
            currentPos = this.transform.position;

            // nextPos�Ɏ�����position��X��+1�̒l�����Z����
            nextPos += Vector3.right;

            // moveTime��0�b�ɑ������
            moveTime = 0f;

            // isMove��true��������
            isMove = true;
        }


        // �����AisMove��true�Ȃ�
        if (isMove == true)
        {
            // moveTime��Time.deltaTime�𑫂��Ă���
            moveTime += Time.deltaTime;
        }

        // float�̕ϐ���ratio�i���j���쐬���AmoveTime��1�Ŋ������l��������
        float ratio = moveTime / 1;

        // ������position��Vector3.Lerp(currentPos,nextPos,ratio)��������
        this.transform.position = Vector3.Lerp(currentPos, nextPos, ratio);

        // �����Aratio��1�𒴂�����
        if (ratio > 1)
        {
            // isMove��false�ɂ���
            isMove = false;
        }



        //// �@:A�L�[�̉������擾���A�����̃|�W�V������x�������ɑ΂���-1�����Z����
        //if (Keyboard.current.aKey.wasPressedThisFrame)
        //{
        //    this.transform.position += Vector3.left;
        //}
        //// �A:S�L�[�̉������擾���A�����̃|�W�V������z�������ɑ΂���-1�����Z����
        //if (Keyboard.current.sKey.wasPressedThisFrame)
        //{
        //    this.transform.position += Vector3.back;
        //}
        //// �B:D�L�[�̉������擾���A�����̃|�W�V������x�������ɑ΂���+1�����Z����
        //if (Keyboard.current.dKey.wasPressedThisFrame)
        //{
        //    this.transform.position += Vector3.right;
        //}


    }
}
