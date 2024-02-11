using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// 敵のHitPoint管理
    /// </summary>
    private Health enemyHealth;


    /// <summary>
    /// 自分が持っているAttackPoint達
    /// </summary>
    private List<Transform> attackPoints = new List<Transform>();

    /// <summary>
    /// 敵のダメージ用コンポーネント
    /// </summary>
    private Damageable enemyDamageable;

    /// <summary>
    /// ターゲットとなるGameObjectの位置
    /// </summary>
    public Transform TargetObject;

    /// <summary>
    /// EnemyのNavMeshAgent
    /// </summary>
    private NavMeshAgent enemyNavMeshAgent;


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
        // NavMeshAgentコンポーネントを取得
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();


        // このゲームオブジェクトからHealthのコンポーネントを取得し、enemyHealthに代入する
        enemyHealth = GetComponent<Health>();

        // もし、エネミーヘルスがあったら（nullでなかったら）
        if (enemyHealth != null)
        {
            // エネミーヘルスのOnDieに、エネミーコントローラーのOnDieを設定する
            enemyHealth.OnDie += OnDie;
        }

        //敵を構成するgameObjectをすべて取得する
        var enemyParts = this.gameObject.GetComponentsInChildren<Transform>();

        foreach (var attackPoint in enemyParts)
        {
            // AttackPointTugのタグのTransformだったら
            if (attackPoint.tag == "AttackObjectTag")
            {
                // attackPointsに追加
                attackPoints.Add(attackPoint);
            }
        }

        enemyDamageable = GetComponentInChildren<Damageable>();

        // damage判定に自身のAttackPointを伝える
        enemyDamageable.MyAttackPoints = attackPoints;
    }

    private void Update()
    {
        if (enemyNavMeshAgent == null)
        {
            return;
        }
        // NavMeshが準備できているなら
        if (enemyNavMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            // NavMeshAgentに目的地をセット
            enemyNavMeshAgent.SetDestination(TargetObject.position);
        }
    }
}
