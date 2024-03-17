using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    /// <summary>
    /// CardData�̔z����쐬���܂��B
    /// �z��Ƃ́A�f�[�^�̏W�܂�̂��Ƃł��B
    /// ����͒P���Ɉꎟ���̔z����g���܂��B
    /// �C���[�W�Ƃ��Ă̓g�����v�̈ꖇ�ꖇ�̏��53������
    /// �����n�C�A���h���[�̓W���[�J�[�Ȃ��Ȃ̂�52���ɂ��܂�
    /// �ꊇ�ŏ����ł���ϐ��Ǝv���Ă��������B
    /// </summary>
    private CardData[] cardDatas = new CardData[52];


    // Start is called before the first frame update
    void Start()
    {
        // for���͑�����(int i)���������(cardDatas.length��cardDatas�̑���)�ɂȂ�܂ŁA
        // ��O�����̑�����s�Ȃ��܂��B
        // �������肢���ƁA�C�ӂ̐��܂ŌJ��Ԃ����s�Ȃ��������Ɏg�p���܂��B
        for (int i = 0; i < cardDatas.Length; i++)
        // 0���X�^�[�g�Ȃ̂ŁA0����52�܂ł̔z��ł��I����53�̔z��
        {
            // �܂�id�������w�肵�����CardData��new�ō쐬���܂��B
            // i�̐��ł����A��T�ڂ�0,��T�ڂ�1,�O�T�ڂ�2�Ƒ����Ă����܂��B
            // ���̃R�[�h���������Ă��邩�Ƃ����ƁAcardData��0�Ԗځi��ԍŏ��j�̃f�[�^��
            // iD�������ď�����Ԃō쐬���Ă��܂��B
            cardDatas[i] = new CardData(CardSuitJudge(i), CardNumJudge(i), i);

            // ����i�Ƃ����l���g����Suit��CardNum�����肵�����Ǝv���܂��B

            Debug.Log($"���̃J�[�h�̃f�[�^��" +
                $"{cardDatas[i].CardSuit}��" +
                $"{cardDatas[i].CardNum}");
        }
    }

    /// <summary>
    /// �O�����烉���_����CardData���擾���邽�߂̃��\�b�h
    /// </summary>
    /// <returns></returns>
    public CardData GetCardData()
    {
        // Random.Range(int min, int max)��max�܂ł̒l�������_���Ɏ擾�ł��܂��B
        // int�Ŏw�肵���ꍇ�́Amax�̒l�͓���Ȃ��̂�+1������Ɨǂ��ł��B
        return cardDatas[Random.Range(0, cardDatas.Length)];
    }




    /// <summary>
    /// CardData.Suits���A�����ɂ���Čv�Z���ĕԂ����\�b�h
    /// �Ⴆ�Α�������0�̏ꍇ�A0��13�Ŋ����Ă�0�Ȃ̂�
    /// CardData.Suits��Club�ƂȂ�܂��B
    /// �܂��͑�������15�̏ꍇ�A15��13�Ŋ�������1�]��2�ƂȂ�܂��B
    /// int�^�̏ꍇ�͗]��͖��������̂�1�Ƃ����l���c��܂��B
    /// �����CardData.Suits�ɃL���X�g�����Dia�ƂȂ�܂��B
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public CardData.Suits CardSuitJudge(int num)
    {
        // �^�𑼂̌^�ɕϊ����邱�Ƃ�Cast�Ƃ����܂��B
        // int�^��CardData.Suits.Max��Cast����ƁA4�ƂȂ�܂��B
        for (int i = 0; i < (int)CardData.Suits.Max; i++) // Max
        {
            if (num / 13 == i)
            {
                return (CardData.Suits)i; // CardData.cs��Suits�^�ŕϊ�
            }
        }
        return CardData.Suits.Invalid;
    }

    // public�C���q��int�^��Ԃ�CardNumJudge(int num)�Ƃ������\�b�h���쐬���Ă��������B
    // ���\�b�h�̒��g��for�����g���Aint i��13�ɂȂ�܂ŁA�J��Ԃ��̏������s�Ȃ��܂��B

    public int CardNumJudge(int num)
    {
        for (int i = 0; i < 13; i++)
        {
            // for���̒��g�͂����A������num��13�Ŋ������]�肪�Ai�ƃC�R�[���̊֌W�ł���΁A
            if (num % 13 == i)
            {
                // i��1�𑫂������̂�return���܂��B
                return i + 1;
            }
        }
        // for�����߂������return 0��Ԃ��Ă��������B
        return 0;
    }
}
