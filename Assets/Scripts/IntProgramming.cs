using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntProgramming : MonoBehaviour
{
    /// <summary>
    /// ���������̃_���[�W��\���ϐ�
    /// </summary>
    private int damage = 0;
    /// <summary>
    /// �l�Ԃ̗͂�\���ϐ�
    /// </summary>
    private int humanPower = 100;
    /// <summary>
    /// ����̗͂�\���ϐ�
    /// </summary>
    private int weaponPower = 100;

    /// <summary>
    /// ���̕���̗͂�\���ϐ�
    /// </summary>
    private int swordWeaponPower = 150;
    /// <summary>
    /// ���̕���̗͂�\���ϐ�
    /// </summary>
    private int SpearWeaponPower = 120;
    /// <summary>
    /// ���̕���̗͂�\���ϐ�
    /// </summary>
    private int axeWeaponPower = 180;

    /// <summary>
    /// 
    /// </summary>
    private int hammerWeaponPower = 250;

    /// <summary>
    /// 
    /// </summary>
    private int wandWeaponPower = 100;

    /// <summary>
    /// ��
    /// </summary>
    private int whipWeaponPower = 600;

    // private int shieldDefencePower = 50;
    // private int armorDefencePower = 30;




    /// <summary>
    /// ���enum�^�̕ϐ��̒��ɕ����̒l���ݒ�ł���
    /// ����͕���̎�ނ�ݒ肵�܂�
    /// </summary>
    public enum WeaponTypes
    {
        Invalid = -1,
        Sword,
        Spear,
        Axe,
        Hammer,
        Wand,
        Whip// ��
    }

    /*
    public enum DefenceTypes
    {
        Shield,// ��
        Armor// �Z
    }
    */



    //�ۑ�F������int�^�̖h��͂�ǉ�����
    // public int TakeDamage(WeaponTypes weaponTypes,DefenceTypes defensePower)
    public int TakeDamage(WeaponTypes weaponTypes, int defensePower)
    {

        // switch���͈�̒l�ɑ΂��Ĕ�r���s�Ȃ����Ƃ��ł���
        switch (weaponTypes)
        {
            case WeaponTypes.Sword:
                damage = humanPower + swordWeaponPower;
                break;
            case WeaponTypes.Spear:
                damage = humanPower + SpearWeaponPower;
                break;
            case WeaponTypes.Axe:
                damage = humanPower + axeWeaponPower;
                break;
            case WeaponTypes.Hammer:
                damage = humanPower + hammerWeaponPower;
                break;
            case WeaponTypes.Wand:
                damage = humanPower + wandWeaponPower;
                break;
            case WeaponTypes.Whip:
                damage = humanPower + whipWeaponPower;
                break;
        }

        // ����damage��0����������ꍇ�͂P�Ƃ���
        if (damage - defensePower <= 0)
        {
            damage = 1;
            return damage;
        }
        return damage - defensePower;
    }

    /*
    switch (defensePower)
    {
        case DefenceTypes.Shield:
            damage = humanPower + shieldDefencePower;
            break;
        case DefenceTypes.Armor:
            damage = humanPower + armorDefencePower;
            break;
    }
    */






    /*
    /// <summary>
    /// �����̃t���O�ɂ����damage��Ԃ�
    /// </summary>
    /// <param name="isSword">�����g���Ă���ꍇ</param>
    /// <param name="isSpear">�����g���Ă���ꍇ</param>
    /// <param name="isAxe">�����g���Ă���ꍇ</param>
    /// <returns></returns>
    public int TakeDamage(bool isSword, bool isSpear, bool isAxe)
    {
        if (isSword)
        {
            damage = humanPower + swordWeaponPower;
        }
        if (isSpear)
        {
            damage = humanPower + SpearWeaponPower;
        }
        if (isAxe)
        {
            damage = humanPower + axeWeaponPower;
        }
        return damage;
    }
    */

    private int baseLevelupPoint = 30;
    private int baseRate = 2;

    // ���䐔�񃁃\�b�h an = a1 * r**(n-1)
    // 
    public int GetPlayerLevelupPoint(int level)
    {
        return baseLevelupPoint * (baseRate * (level - 1));
    }


    // Start is called before the first frame update
    void Start()
    {
        /*
        // �ϐ����m���g���ă��\�b�h���Ōv�Z���邱�Ƃ��ł��܂��B
        //damage = humanPower + weaponPower;
        //Debug.Log(damage);// 200

        //damage = humanPower + swordWeaponPower + axeWeaponPower;
        //Debug.Log(damage); // 430

        // ���������Ă����ꍇ�̃_���[�W
        Debug.Log(TakeDamage(true, false, false));// 250
        // ���������Ă����ꍇ�̃_���[�W
        Debug.Log(TakeDamage(false, true, false));// 220
        // ���������Ă����ꍇ�̃_���[�W
        Debug.Log(TakeDamage(false, false, true));// 280
        */




        // enum�^�Œ�`����WeaponTypes�ɂ��_���[�W�l�i���̏ꍇ�j�A�f�B�t�F���X��100�̏ꍇ
        // Debug.Log�ŏo��
        Debug.Log(TakeDamage(WeaponTypes.Sword, 100));// 150


        Debug.Log("Level2�ɕK�v�Ȍo���l�́F" + GetPlayerLevelupPoint(2));
        Debug.Log("Level3�ɕK�v�Ȍo���l�́F" + GetPlayerLevelupPoint(3));
        Debug.Log("Level4�ɕK�v�Ȍo���l�́F" + GetPlayerLevelupPoint(4));
        Debug.Log("Level5�ɕK�v�Ȍo���l�́F" + GetPlayerLevelupPoint(5));

    }
}
