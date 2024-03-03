using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntProgramming : MonoBehaviour
{
    /// <summary>
    /// 何がしかのダメージを表す変数
    /// </summary>
    private int damage = 0;
    /// <summary>
    /// 人間の力を表す変数
    /// </summary>
    private int humanPower = 100;
    /// <summary>
    /// 武器の力を表す変数
    /// </summary>
    private int weaponPower = 100;

    /// <summary>
    /// 剣の武器の力を表す変数
    /// </summary>
    private int swordWeaponPower = 150;
    /// <summary>
    /// 槍の武器の力を表す変数
    /// </summary>
    private int SpearWeaponPower = 120;
    /// <summary>
    /// 斧の武器の力を表す変数
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
    /// 鞭
    /// </summary>
    private int whipWeaponPower = 600;

    // private int shieldDefencePower = 50;
    // private int armorDefencePower = 30;




    /// <summary>
    /// 一つのenum型の変数の中に複数の値が設定できる
    /// 今回は武器の種類を設定します
    /// </summary>
    public enum WeaponTypes
    {
        Invalid = -1,
        Sword,
        Spear,
        Axe,
        Hammer,
        Wand,
        Whip// 鞭
    }

    /*
    public enum DefenceTypes
    {
        Shield,// 盾
        Armor// 鎧
    }
    */



    //課題：引数にint型の防御力を追加する
    // public int TakeDamage(WeaponTypes weaponTypes,DefenceTypes defensePower)
    public int TakeDamage(WeaponTypes weaponTypes, int defensePower)
    {

        // switch文は一つの値に対して比較を行なうことができる
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

        // もしdamageが0を下回った場合は１とする
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
    /// 引数のフラグによってdamageを返す
    /// </summary>
    /// <param name="isSword">剣を使っている場合</param>
    /// <param name="isSpear">槍を使っている場合</param>
    /// <param name="isAxe">斧を使っている場合</param>
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

    // 等比数列メソッド an = a1 * r**(n-1)
    // 
    public int GetPlayerLevelupPoint(int level)
    {
        return baseLevelupPoint * (baseRate * (level - 1));
    }


    // Start is called before the first frame update
    void Start()
    {
        /*
        // 変数同士を使ってメソッド内で計算することができます。
        //damage = humanPower + weaponPower;
        //Debug.Log(damage);// 200

        //damage = humanPower + swordWeaponPower + axeWeaponPower;
        //Debug.Log(damage); // 430

        // 剣を持っていた場合のダメージ
        Debug.Log(TakeDamage(true, false, false));// 250
        // 槍を持っていた場合のダメージ
        Debug.Log(TakeDamage(false, true, false));// 220
        // 斧を持っていた場合のダメージ
        Debug.Log(TakeDamage(false, false, true));// 280
        */




        // enum型で定義したWeaponTypesによるダメージ値（剣の場合）、ディフェンス力100の場合
        // Debug.Logで出力
        Debug.Log(TakeDamage(WeaponTypes.Sword, 100));// 150


        Debug.Log("Level2に必要な経験値は：" + GetPlayerLevelupPoint(2));
        Debug.Log("Level3に必要な経験値は：" + GetPlayerLevelupPoint(3));
        Debug.Log("Level4に必要な経験値は：" + GetPlayerLevelupPoint(4));
        Debug.Log("Level5に必要な経験値は：" + GetPlayerLevelupPoint(5));

    }
}
