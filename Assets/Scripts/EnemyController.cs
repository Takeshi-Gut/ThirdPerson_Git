using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// �G��HitPoint�Ǘ�
    /// </summary>
    private Health enemyHealth;


    /// <summary>
    /// �����������Ă���AttackPoint�B
    /// </summary>
    private List<Transform> attackPoints = new List<Transform>();

    /// <summary>
    /// �G�̃_���[�W�p�R���|�[�l���g
    /// </summary>
    private Damageable enemyDamageable;

    /// <summary>
    /// �^�[�Q�b�g�ƂȂ�GameObject�̈ʒu
    /// </summary>
    public Transform TargetObject;

    /// <summary>
    /// Enemy��NavMeshAgent
    /// </summary>
    private NavMeshAgent enemyNavMeshAgent;


    /// <summary>
    /// ���S�����Ƃ��̏���
    /// </summary>
    private void OnDie()
    {
        // �����̃Q�[���I�u�W�F�N�g�̃A�N�e�B�u��؂�B����\���A������B
        this.gameObject.SetActive(false);
    }


    // Start is called before the first frame update
    private void Start()
    {
        // NavMeshAgent�R���|�[�l���g���擾
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();


        // ���̃Q�[���I�u�W�F�N�g����Health�̃R���|�[�l���g���擾���AenemyHealth�ɑ������
        enemyHealth = GetComponent<Health>();

        // �����A�G�l�~�[�w���X����������inull�łȂ�������j
        if (enemyHealth != null)
        {
            // �G�l�~�[�w���X��OnDie�ɁA�G�l�~�[�R���g���[���[��OnDie��ݒ肷��
            enemyHealth.OnDie += OnDie;
        }

        //�G���\������gameObject�����ׂĎ擾����
        var enemyParts = this.gameObject.GetComponentsInChildren<Transform>();

        foreach (var attackPoint in enemyParts)
        {
            // AttackPointTug�̃^�O��Transform��������
            if (attackPoint.tag == "AttackObjectTag")
            {
                // attackPoints�ɒǉ�
                attackPoints.Add(attackPoint);
            }
        }

        enemyDamageable = GetComponentInChildren<Damageable>();

        // damage����Ɏ��g��AttackPoint��`����
        enemyDamageable.MyAttackPoints = attackPoints;
    }

    private void Update()
    {
        if (enemyNavMeshAgent == null)
        {
            return;
        }
        // NavMesh�������ł��Ă���Ȃ�
        if (enemyNavMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            // NavMeshAgent�ɖړI�n���Z�b�g
            enemyNavMeshAgent.SetDestination(TargetObject.position);
        }
    }
}
