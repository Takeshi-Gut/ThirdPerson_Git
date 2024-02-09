using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// 敵のHitPoint管理
    /// </summary>
    private Health enemyHealth;

    /// <summary>
    /// 死亡したときの処理
    /// </summary>
    private void OnDie()
    {
        // 自分のゲームオブジェクトのアクティブを切る。→非表示、消える。
        this.gameObject.SetActive(false);
    }


    // Start is called before the first frame update
    private void Start()
    {
        // このゲームオブジェクトからHealthのコンポーネントを取得し、enemyHealthに代入する
        enemyHealth = GetComponent<Health>();

        // もし、エネミーヘルスがあったら（nullでなかったら）
        if (enemyHealth != null)
        {
            // エネミーヘルスのOnDieに、エネミーコントローラーのOnDieを設定する
            enemyHealth.OnDie += OnDie;
        }
    }
}
