using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Player��HitPoint�Ǘ�
    /// </summary>
    private Health playerHealth;

    /// <summary>
    /// ���S�����Ƃ��̏���
    /// </summary>
    private void OnDie ( )
    {
        // �����̃Q�[���I�u�W�F�N�g�̃A�N�e�B�u��؂�B����\���A������B
        this.gameObject.SetActive ( false );
    }


    // Start is called before the first frame update
    private void Start ( )
    {
        // ���̃Q�[���I�u�W�F�N�g����Health�̃R���|�[�l���g���擾���AplayerHealth�ɑ������
        playerHealth = GetComponent<Health> ( );

        // �����A�v���C���[�w���X����������inull�łȂ�������j
        if ( playerHealth != null )
        {
            // �v���C���[�w���X��OnDie�ɁA�v���C���[�R���g���[���[��OnDie��ݒ肷��
            playerHealth.OnDie += OnDie;
        }
    }
}
