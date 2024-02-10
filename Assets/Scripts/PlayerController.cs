using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// PlayerのHitPoint管理
    /// </summary>
    private Health playerHealth;

    /// <summary>
    /// 死亡したときの処理
    /// </summary>
    private void OnDie ( )
    {
        // 自分のゲームオブジェクトのアクティブを切る。→非表示、消える。
        this.gameObject.SetActive ( false );
    }


    // Start is called before the first frame update
    private void Start ( )
    {
        // このゲームオブジェクトからHealthのコンポーネントを取得し、playerHealthに代入する
        playerHealth = GetComponent<Health> ( );

        // もし、プレイヤーヘルスがあったら（nullでなかったら）
        if ( playerHealth != null )
        {
            // プレイヤーヘルスのOnDieに、プレイヤーコントローラーのOnDieを設定する
            playerHealth.OnDie += OnDie;
        }
    }
}
