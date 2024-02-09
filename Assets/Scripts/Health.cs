using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    /// <summary>
    /// 最大HitPoint
    /// </summary>
    public float MaxHealth = 10f;

    /// <summary>
    /// 現在のHitPoint
    /// </summary>
    private float currentHealth;

    /// <summary>
    /// 死んでいるかのフラグ
    /// </summary>
    public bool IsDead = false;

    /// <summary>
    /// 死亡した時の処理
    /// </summary>
    public UnityAction OnDie;


    // Start is called before the first frame update
    private void Start()
    {
        // MaxHealthをcurrentHealthに代入して初期化する
        currentHealth = MaxHealth;
    }

    /// <summary>
    /// ダメージを受けるメソッド
    /// </summary>
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        // 0を下回った場合
        if (currentHealth <= 0)
        {
            IsDead = true;
            currentHealth = 0;
            // 死亡した時の処理に何か登録されていれば、それを実行する
            OnDie?.Invoke();
        }
    }
}
