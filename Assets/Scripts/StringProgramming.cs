using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringProgramming : MonoBehaviour
{
    /// <summary>
    /// string�^�̕ϐ��ɑ������Ƃ���""�ň͂񂾒��ő���ł���
    /// </summary>
    private string userName = "�Ԏq";
    private string userAddress = "���s�{";

    /// <summary>
    /// ������^�ϐ��̒��g����ɂ�������΁Astring.Empty�ő������
    /// </summary>
    private string userPetName = string.Empty;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(userName + "�����");

        Debug.Log(userAddress + "�ɏZ��ł���");

        // $"{}"�ň͂�{}�̕����͕�����ȊO�ł�������Ƃ��Ĉ�����
        Debug.Log($"{userName}����̃X�R�A��{123}�_�ł�");
    }
}
