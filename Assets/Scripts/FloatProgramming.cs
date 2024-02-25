using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatProgramming : MonoBehaviour
{
    /// <summary>
    /// 消費税率
    /// </summary>
    private float salesTaxRate = 1.1f;

    /// <summary>
    /// 軽減税率
    /// </summary>
    private float reducedTaxRate = 1.08f;

    private float humanHight = 1.8f;
    private float humanWeight = 70f;

    /// <summary>
    /// 消費税をこのclassの外から取得したい場合は
    /// このように書くと、このClassの外から値を変更されずに済む
    /// </summary>
    public float GetSalesTaxRate
    {
        get { return salesTaxRate; }
    }



    /// <summary>
    /// 商品の値段に消費税をかけたのもを返す（引数で軽減税率をboolで判断）
    /// </summary>
    /// <param name="value">引数と呼び、このメソッドの中で使う変数。今回は値段とする</param>
    /// <param name="isReduce">軽減税率かどうかtureかfalseかが代入される</param>
    /// <returns></returns>
    public float GetSalesValue(float value, bool isReduce = false)
    {
        // 値を返すメソッドの中でif文を使うことも可能です。
        // もし軽減だったらreducedTaxRateを掛ける
        if (isReduce)
        {
            return reducedTaxRate * value;
        }

        // returnは返すという意味であり、このGetSalesValueを呼べば、計算結果を返してくれる
        return salesTaxRate * value;
    }
    /// <summary>
    /// 軽減税率で商品の値段に消費税をかけたのもを返す（ゲッター）
    /// </summary>
    public float GetReducedSalesTaxRate
    {
        get { return reducedTaxRate; }
    }

    /// <summary>
    /// 健康保険料（2024年度の京都の税率）
    /// </summary>
    private float healthInsurancePremiumRate = 0.1009f;

    /// <summary>
    /// 介護保険料率
    /// </summary>
    private float nursingcareInsurancePremiumRate = 0.0182f;

    /// <summary>
    /// 厚生年金保険料率
    /// </summary>
    private float welfarePensionInsurancePremiumRate = 0.183f;

    /// <summary>
    /// 雇用保険料率（労働者負担分）
    /// </summary>
    private float unemploymentInsurancePremiumRate = 0.006f;

    /// <summary>
    /// ベースとなる所得税率（330～695）
    /// </summary>
    private float incomeTaxRate = 0.2f;

    /// <summary>
    /// 月額の支払いの計算（住民税は考慮せず）
    /// </summary>
    /// <param name="paymentValue"></param>
    /// <returns></returns>
    public float GetMonthlyPayment(float paymentValue)
    {
        float healthInsurancePremium = paymentValue * healthInsurancePremiumRate;

        float nursingcareInsurancePremium = paymentValue * nursingcareInsurancePremiumRate;

        float welfarePensionInsurancePremium = paymentValue * welfarePensionInsurancePremiumRate;

        float unemploymentInsurancePremium = paymentValue * unemploymentInsurancePremiumRate;



        // 控除額
        float dedectionAmount = (paymentValue * 12) * 0.2f + 440000;
        // 年間の給与
        float yearPaymentValue = paymentValue * 12;
        // 給与額
        float payment = dedectionAmount - yearPaymentValue;
        // 所得額
        float incomeTax = (195 * 0.05f + payment * 0.1f) / 12;
        Debug.Log(incomeTax);


        // 数式と同じように、（）で囲った部分が優先して計算される
        return paymentValue -= (healthInsurancePremium + nursingcareInsurancePremium
            + welfarePensionInsurancePremium + unemploymentInsurancePremium + incomeTax);

    }





    /// <summary>
    /// UnityEngineで使える実行処理
    /// ゲームが始まった時に１回だけ実行される
    /// </summary>
    // Start is called before the first frame update
    private void Start()
    {
        // ログに消費税が計算された後の商品の値段を出す
        Debug.Log(GetSalesValue(500)); // 550

        // 第二引数にtureを設定しているので、軽減税率での値段を出す
        Debug.Log(GetSalesValue(500, true));

        Debug.Log(GetMonthlyPayment(300000));// 225840

        // BMIを計算。体重÷身長×身長。var方でもできる
        string bmi = ((humanWeight / (humanHight * humanHight)).ToString("F2"));

        //コメントで出力。身長●cm、体重●kgの方のBMIは●です。
        Debug.Log($"身長{humanHight * 100}cm、体重{humanWeight}kgの方のBMIは{bmi}です。");

    }
}
