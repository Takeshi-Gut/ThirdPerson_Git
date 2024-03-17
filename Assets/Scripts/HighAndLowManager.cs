using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HighAndLowManager : MonoBehaviour
{
    // public�C���q��Player�^�̕ϐ�Player���쐬���Ă��������B
    public Player Player;

    // public�C���q��CPU�^�̕ϐ�CPU�쐬���Ă��������B
    public CPS CPU;

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[��������Ă��邩�𔻕ʂ��Ă��������B
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // �ϐ�Player�̒��ɂ���CardManager����GetCardData���Ăяo���A
            // �ϐ�Player��PlayerCard�ɑ�����Ă��������B
            Player.PlayerCard = Player.CardManager.GetCardData();

            //�ϐ�CPU�������悤��CPUCard�ɑ�����Ă��������B
            CPU.CPUCard = CPU.CardManager.GetCardData();


            // ��1�@Debug.Log��Player��PlayerCard��CardNum��CPU��CPUCard��CardNum���o�͂��Ă��������B

            Debug.Log("Player�̃g�����v�i���o�["+Player.PlayerCard.CardNum+"��"+ "CPU�̃g�����v�i���o�["+CPU.CPUCard.CardNum);

            // ��2�@Player��PlayerCard��CardNum��CPU��CPUCard��CardNum���C�R�[���������ꍇ��
            // Degug.Log�Ƀh���[�ƕ\������return���Ă��������B

            if(Player.PlayerCard.CardNum == CPU.CPUCard.CardNum)
            {
                Debug.Log("�h���[");
            }


            //���̂Ȃ��ł����A�ϐ�Player��PlayerCard��CardNum���A
            // �ϐ�CPU��CPUCard��CardNum���傫����΁A
            // Debug.Log��"Player�̏���"�ƕ\�����Ă��������B
            if (Player.PlayerCard.CardNum > CPU.CPUCard.CardNum)
            {
                Debug.Log("Player�̏���");
            }

            // ��������Ȃ���΁ADebug.Log��"CPU�̏���"�ƕ\�����Ă��������B
            else
            {
                Debug.Log("CPU�̏���");
            }
        }
    }
}

