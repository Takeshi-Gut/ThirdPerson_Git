using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapYear : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // LeapYearJudge(2000)�Ə����A���̃��\�b�h������������ł��Ă��邩���m�F����
        LeapYearJudge(2000);

    }

    // public�C���q��void�^��LeapYearJudge�Ƃ������\�b�h���쐬���Ă��������B
    // ��������int�^��year���w�肵�Ă��������B
    public void LeapYearJudge(int year)
    {
        // �����Ayear��4�Ŋ���؂ꂽ��Debug.Log��"�[�N"�Əo�͂��Ă��������B
        // ��������Ȃ��ꍇ��Debug.Log��"�[�N����Ȃ�"�Əo�͂��܂��B
        if (year % 4 == 0)
        {
            // 100�Ŋ���؂�āA400�ł�����؂ꂽ��Debug.Log��"�[�N"�Əo�͂��Ă��������B
            if (year % 100 == 0 && year % 400 == 0)
            {
                Debug.Log("�[�N");
                // Debug.Log�̉��̍s��return���Ă��������B
                return;
            }

            // 100�Ŋ���؂ꂽ��[�N�ł͂Ȃ��̂�Debug.Log��"�[�N����Ȃ�"�Əo�͂��Ă��������B
            if (year % 100 == 0)
            {
                Debug.Log("�[�N����Ȃ�");
                // Debug.Log�̉��̍s��return���Ă��������B
                return;
            }



            Debug.Log("�[�N");
        }
        else
        {
            Debug.Log("�[�N����Ȃ�");
        }
    }
}
