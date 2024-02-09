using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    /// <summary>
    /// �ő�HitPoint
    /// </summary>
    public float MaxHealth = 10f;

    /// <summary>
    /// ���݂�HitPoint
    /// </summary>
    private float currentHealth;

    /// <summary>
    /// ����ł��邩�̃t���O
    /// </summary>
    public bool IsDead = false;

    /// <summary>
    /// ���S�������̏���
    /// </summary>
    public UnityAction OnDie;


    // Start is called before the first frame update
    private void Start()
    {
        // MaxHealth��currentHealth�ɑ�����ď���������
        currentHealth = MaxHealth;
    }

    /// <summary>
    /// �_���[�W���󂯂郁�\�b�h
    /// </summary>
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        // 0����������ꍇ
        if (currentHealth <= 0)
        {
            IsDead = true;
            currentHealth = 0;
            // ���S�������̏����ɉ����o�^����Ă���΁A��������s����
            OnDie?.Invoke();
        }
    }
}
