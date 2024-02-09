using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// �G��HitPoint�Ǘ�
    /// </summary>
    private Health enemyHealth;

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
        // ���̃Q�[���I�u�W�F�N�g����Health�̃R���|�[�l���g���擾���AenemyHealth�ɑ������
        enemyHealth = GetComponent<Health>();

        // �����A�G�l�~�[�w���X����������inull�łȂ�������j
        if (enemyHealth != null)
        {
            // �G�l�~�[�w���X��OnDie�ɁA�G�l�~�[�R���g���[���[��OnDie��ݒ肷��
            enemyHealth.OnDie += OnDie;
        }
    }
}
