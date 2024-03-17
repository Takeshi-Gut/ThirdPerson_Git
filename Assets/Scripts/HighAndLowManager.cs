using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HighAndLowManager : MonoBehaviour
{
    // public修飾子でPlayer型の変数Playerを作成してください。
    public Player Player;

    // public修飾子でCPU型の変数CPU作成してください。
    public CPS CPU;

    // Update is called once per frame
    void Update()
    {
        // スペースキーが押されているかを判別してください。
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // 変数Playerの中にあるCardManagerからGetCardDataを呼び出し、
            // 変数PlayerのPlayerCardに代入してください。
            Player.PlayerCard = Player.CardManager.GetCardData();

            //変数CPUも同じようにCPUCardに代入してください。
            CPU.CPUCard = CPU.CardManager.GetCardData();


            // ※1　Debug.LogでPlayerのPlayerCardのCardNumとCPUのCPUCardのCardNumを出力してください。

            Debug.Log("Playerのトランプナンバー"+Player.PlayerCard.CardNum+"と"+ "CPUのトランプナンバー"+CPU.CPUCard.CardNum);

            // ※2　PlayerのPlayerCardのCardNumとCPUのCPUCardのCardNumがイコールだった場合は
            // Degug.Logにドローと表示してreturnしてください。

            if(Player.PlayerCard.CardNum == CPU.CPUCard.CardNum)
            {
                Debug.Log("ドロー");
            }


            //そのなかでもし、変数PlayerのPlayerCardのCardNumが、
            // 変数CPUのCPUCardのCardNumより大きければ、
            // Debug.Logで"Playerの勝ち"と表示してください。
            if (Player.PlayerCard.CardNum > CPU.CPUCard.CardNum)
            {
                Debug.Log("Playerの勝ち");
            }

            // そうじゃなければ、Debug.Logで"CPUの勝ち"と表示してください。
            else
            {
                Debug.Log("CPUの勝ち");
            }
        }
    }
}

