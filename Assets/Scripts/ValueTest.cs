using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueTest : MonoBehaviour
{
    public string StartText = "�X�^�[�g";

    /// <summary>
    /// �����_�����ĂȂ�����int�Ő錾���܂�
    /// </summary>
    private int age = 0; // private�Ȃ̂œ������͏�����

    /// <summary>
    /// �����_�����Ă��鐔��float�Ő錾���܂�
    /// </summary>
    private const float taxRate = 1.1f;

    /// <summary>
    /// �吳�̎n�܂����N
    /// </summary>
    private const int Taisho = 1912;

    /// <summary>
    /// ���a�̎n�܂����N
    /// </summary>
    private const int Showa = 1926;

    /// <summary>
    ///  �����̎n�܂����N
    /// </summary>
    private const int Heisei = 1989;

    /// <summary>
    /// �ߘa�̎n�܂����N
    /// </summary>
    private const int Reiwa = 2019;



    // �ŏ��ɂP�񂾂����s����郁�\�b�h�i�����j
    //�Q�[���̏������ȂǂɎg��
    void Start()
    {
        //�萔�Ƃ͕ϐ��Ƃ͈Ⴂ�A�錾��ɕς��邱�Ƃ��ł��Ȃ�
        //Reiwa = 2020; // �X�^�[�g�̒��ł��G���[�ɂȂ�܂�

        // age��20��������
        age = 20;

        // age��21��������
        // age = 21;

        // ���Z�q
        age -= 1;
        // �Ӗ��͂���ƈꏏ�ł��B
        // age = 20-1;

        age += 1;
        // age = 20 + 1;

        age *= 2;
        // age = 20 * 2;

        age /= 2;
        // age = 20/2;

        age %= 2;
        // �]��Ȃ̂ŉE�ӂŊ��������܂�������Ă���܂��B


        //if�͂����`��������A
        // �Ƃ��������Ńu���b�N�̒��̏��������邩�ǂ�����ݒ肷�邱�Ƃ��ł��܂��B
        // 21�Ȃǂ������珈���͒ʂ�܂���B
        if (age == 20)
        {
            Debug.Log(age);
        }

        // ���K�Fage��23��������
        age = 23;
        // Debug.Log�̏��������̒���2024-age���s��
        Debug.Log(2024 - age);

        // ���K�Fage��56��������
        age = 56;
        // Debug.Log�̏��������̒���2024-age���s�Ȃ��B
        Debug.Log(2024 - age);

        // �V����int�^��playerAge�̕ϐ����쐬���A�C�ӂ̐��ő������B
        int playerAge = 100;

        // playerAge�̒l�𔻒肵�A
        // ���a���܂�i1926���O�j�A
        // �������܂�i1988����j�A
        // �ߘa���܂�i2019����j�A
        // �吳���܂�i1926���O�j�A
        // �Ƃ���Debug.Log���o��


        int bornAge = 2024 - playerAge; // playerAge��100�Ƃ���1924


        // bornAge��1924���Ƃ�����
        if (bornAge >= Taisho && bornAge < Showa)
        {
            // �R�R�͒ʂ�
            Debug.Log("�吳���܂�");
        }

        if (bornAge >= Showa && bornAge <= Heisei)
        {
            Debug.Log("���a���܂�");
        }

        if (bornAge > Heisei && bornAge < Reiwa)
        {
            Debug.Log("�������܂�");
        }

        if (bornAge >= Reiwa)
        {
            Debug.Log("�ߘa���܂�");
        }



        float value = 1000;
        value *= taxRate; // ���ӂƉE�ӂ̌^�͑����Ȃ��Ƃ����Ȃ��I
        Debug.Log(value);

        Debug.Log(StartText);


        // SUM�֐�����������܂��B
        // (�l1,�l2)�̃V���v����SUM�֐������܂�
        // �Ⴆ�΃G�N�Z�����Ɓ@=SUM(10,10)�ƃZ���ɑł����ނ�20���Ԃ��Ă��܂�
        Debug.Log(SUM(10, 10)); // Debug.Log��20�ƕ\�������

        // �G�N�Z���ł����Ƃ����Average�֐�������Ă݂Ă�������
        // (�l1,�l2)�̃V���v����AVERAGE�֐�
        Debug.Log(AVERAGE(50, 30)); // Degug.Log��40�Əo��

        Debug.Log($"Average:{AVERAGE(10f, 9f)}");

        // ������3�ɂ���ƁB�B�B
        Debug.Log($"Average:{AVERAGE(10f, 9f,5f)}");
    }

    public int SUM(int value1, int value2) // �J�b�R���������Ƃ���
    {
        return value1 + value2;
    }

    /// <summary>
    /// int�^�̕��ς��o���Ă����̂ŁA�����_����������Ă��܂��B�B�B
    /// </summary>
    public int AVERAGE(int value1, int value2)// �J�b�R��������(�Ђ�����)�Ƃ���
    {
        return (value1 + value2) / 2;
    }

    /// <summary>
    /// float�^�̕��ς��o���Ă����B
    /// </summary>
    public float AVERAGE(float value1, float value2)// �J�b�R��������(�Ђ�����)�Ƃ���
    {
        return (value1 + value2) / 2;
    }

    // �����̐���3��Average�֐����쐬���Ă��������B
    // �����́i�l1,�l2,�l3�j�̂��Ƃł�
    public float AVERAGE(float value1, float value2, float value3)
    {
        return (value1 + value2 + value3) / 3; // �߂�l�A�Ԃ�l
    }

    public float SUM(float value1 ,float value2 ,float value3)
    {
        return value1 + value2 + value3;�@// �����Z�A���v
    }





    // �P�b�ԂɎw�肳�ꂽ�t���[�����A���s�����
    void Update()
    {
        // �R�����g�A�E�g����Ə���������Ȃ��Ȃ�܂�
        //Debug.Log("���s��");
    }
}
