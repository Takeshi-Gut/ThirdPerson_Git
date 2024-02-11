using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    /// <summary>
    /// HitPoint�Ǘ��Ɏg��
    /// </summary>
    private Health health;

    /// <summary>
    /// �^����_���[�W�̊�b
    /// </summary>
    public float BaseDamage = 1f;

    /// <summary>
    /// Damage�̃A�j���[�V�������Đ������邽�߂�
    /// Animator
    /// </summary>
    private Animator animator;


    public List<Transform> MyAttackPoints = new List<Transform>();


    // Start is called before the first frame update
    private void Start()
    {
        // ���̃R���|�[�l���g���ǉ����ꂽGamePbject��
        // �e�̒���Health���Ȃ�����T���Ă���
        health = GetComponentInParent<Health>();

        // ���̃R���|�[�l���g���ǉ����ꂽGamePbject��
        // �e�̒���Animator���Ȃ�����T���Ă��� 
        animator = GetComponentInParent<Animator>();
    }

    /// <summary>
    /// �����蔻��ɓ������Ƃ�
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // Health������A�Ȃ����������Ă��������
        // Tag��������Tag�ƈႤ�ꍇ
        // ���g�̎����Ă���A�^�b�N�|�C���g����Ȃ��ꍇ
        if (health != null && other.tag == "AttackObjectTag")
        {
            // �������Ă���Colider�������̃A�^�b�N�|�C���g��������
            foreach (var myAttackPoint in MyAttackPoints)
            {
                if (other.transform == myAttackPoint)
                {
                    return;
                }
            }




            // health�Ƀ_���[�W��^����
            health.TakeDamage(BaseDamage);

            // Animator���������ꍇ�A
            if (animator != null)
            {
                // Damage�Ƃ������O��Trigger�����s����
                animator.SetTrigger("Damage");
            }
        }
    }
}
