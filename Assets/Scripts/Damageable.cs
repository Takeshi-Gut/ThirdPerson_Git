using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    /// <summary>
    /// HitPoint管理に使う
    /// </summary>
    private Health health;

    /// <summary>
    /// 与えるダメージの基礎
    /// </summary>
    public float BaseDamage = 1f;

    /// <summary>
    /// Damageのアニメーションを再生させるための
    /// Animator
    /// </summary>
    private Animator animator;


    // Start is called before the first frame update
    private void Start()
    {
        // このコンポーネントが追加されたGamePbjectの
        // 親の中にHealthがないかを探していく
        health = GetComponentInParent<Health>();

        // このコンポーネントが追加されたGamePbjectの
        // 親の中にAnimatorがないかを探していく 
        animator = GetComponentInParent<Animator>();
    }

    /// <summary>
    /// 当たり判定に入ったとき
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // Healthがあり、なおかつ当たってきた相手の
        // Tagが自分のTagと違う場合
        if (health != null && other.tag == "AttackObjectTag")
        {
            // healthにダメージを与える
            health.TakeDamage(BaseDamage);

            // Animatorがあった場合、
            if (animator != null)
            {
                // Damageという名前のTriggerを実行する
                animator.SetTrigger("Damage");
            }
        }
    }
}
