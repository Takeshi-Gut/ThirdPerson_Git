using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTemplate : MonoBehaviour
{
    // �@�ŏ��ɕϐ���錾����
    private int num = 0;


    // �AUnity�Ŏ��s����鏈���������Ă���
    // �ŏ���1�񂾂��X�N���v�g�����s����ꍇ�ɏ����ꏊ
    // Start is called before the first frame update
    void Start()
    {
        num = 5;
        Debug.Log($"num��{num}�ŏ���������");
    }

    // �t���[�����ɏ��������s����ꍇ�ɏ����ꏊ
    // Update is called once per frame
    void Update()
    {
        // num�ɖ��t���[����1�𑫂��Ă���
        num++;

        // num�̒l�𔻒肵�Ă��炤
        numJudge(num);
    }

    // �B�����̃��\�b�h�������Ă����i���s����ɂ�Start��UpDate�̒��ŌĂяo���Ȃ��Ƃ����Ȃ��j
    public void numJudge(int num)
    {
        // �����A������num��100�𒴂�����
        if (num > 100)
        {
            // 100�ȏ�̏��������Ȃ�
            return;
        }
        // �����A������num��50������������
        if (num < 50)
        {
            Debug.Log($"{num}��50����");

        }
        // ���if���̔���ȊO��������
        else
        {
            Debug.Log($"{num}��50�ȏ�");
        }
    }
}
