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


    public List<Transform> MyAttackPoints = new List<Transform>();


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
        // 自身の持っているアタックポイントじゃない場合
        if (health != null && other.tag == "AttackObjectTag")
        {
            // 当たってきたColiderが自分のアタックポイントだったら
            foreach (var myAttackPoint in MyAttackPoints)
            {
                if (other.transform == myAttackPoint)
                {
                    return;
                }
            }




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
