using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �e�𐶐����A�O���ɔ��˂���N���X
/// </summary>
public class BulletShooter : MonoBehaviour
{
    // public�C���q��gameObject�^��Bullet�Ƃ����ϐ����쐬���Ă��������B
    public GameObject Bullet;

    // public�C���q��void�^��Shoot�Ƃ������\�b�h���쐬���Ă��������B
    public void Shoot()
    {
        // Bullet��Instantiate���܂��BInstantiate���\�b�h�̑�������Bullet��ݒ肵�܂��B
        // Instantiate����GameObject�����ӂ�bullet�ɑ������
        var bullet = Instantiate(Bullet);

        // ���ӂ�Bullet�̕ϐ�instantiateBullet���쐬���A
        // ���bullet����Bullet�̃R���|�[�l���g���擾���Ă��������B
        Bullet instantiateBullet = bullet.GetComponent<Bullet>();

        // instantiateBullet��bulletInitialize���Ăяo���܂��B
        instantiateBullet.BulletInitialize(this.transform);

    }

    private void Update()
    {
        // �����ABullet��Null����Ȃ��A���A�L�[�{�[�h��z�L�[�������ꂽ��A
        if (Bullet != null && Keyboard.current.zKey.wasPressedThisFrame)
        {
            // Shoot���\�b�h���ĂԁB
            Shoot();
        }
    }
}
