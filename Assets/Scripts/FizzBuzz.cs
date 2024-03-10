using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FizzBuzz : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // FizzBuzzJudge()�������AFizz��Buzz�𔻒肵�Ă��������B
        FizzBuzzJudge(15);
    }

    // public�C���q��void�^�̃��\�b�hFizzBuzzJudge(int num)�Ƃ������\�b�h������Ă��������B
    // void�^�́i�����j�̂݁B�߂�l�A�Ԃ�l�͂Ȃ��B
    // ��������int�^��num���w�肵�Ă��������B
    public void FizzBuzzJudge(int num)
    {
        // num��3��5�̗����Ŋ���؂��Ƃ��́uFizzBuzz�v��Debug.Log�ɏo�͂��Ă��������B
        // �������̔�r�Ώۂ�����ꍇ�́Aif���̏��Ԃ͏�ɏ����Areturn;�łӂ邢�ɂ�����B
        if (num % 3 == 0 && num % 5 == 0)
        {
            Debug.Log("FizzBuzz");
            return;
        }

        // �����Anum��3�Ŋ���؂��Ƃ��́uFizz�v��Debug.Log�ɏo�͂��Ă��������B
        if (num % 3 == 0)
        {
            Debug.Log("Fizz");
            return;
        }

        // �����Anum��5�Ŋ���؂��Ƃ��́uBuzz�v��Debug.Log�ɏo�͂��Ă��������B
        if (num % 5 == 0)
        {
            Debug.Log("Buzz");
            return;
        }

        else
        {
            Debug.Log("3�ł�5�ł�����؂�Ȃ�");
        }
    }
}
