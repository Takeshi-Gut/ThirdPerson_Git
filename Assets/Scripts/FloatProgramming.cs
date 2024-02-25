using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatProgramming : MonoBehaviour
{
    /// <summary>
    /// ����ŗ�
    /// </summary>
    private float salesTaxRate = 1.1f;

    /// <summary>
    /// �y���ŗ�
    /// </summary>
    private float reducedTaxRate = 1.08f;

    private float humanHight = 1.8f;
    private float humanWeight = 70f;

    /// <summary>
    /// ����ł�����class�̊O����擾�������ꍇ��
    /// ���̂悤�ɏ����ƁA����Class�̊O����l��ύX���ꂸ�ɍς�
    /// </summary>
    public float GetSalesTaxRate
    {
        get { return salesTaxRate; }
    }



    /// <summary>
    /// ���i�̒l�i�ɏ���ł��������̂���Ԃ��i�����Ōy���ŗ���bool�Ŕ��f�j
    /// </summary>
    /// <param name="value">�����ƌĂсA���̃��\�b�h�̒��Ŏg���ϐ��B����͒l�i�Ƃ���</param>
    /// <param name="isReduce">�y���ŗ����ǂ���ture��false������������</param>
    /// <returns></returns>
    public float GetSalesValue(float value, bool isReduce = false)
    {
        // �l��Ԃ����\�b�h�̒���if�����g�����Ƃ��\�ł��B
        // �����y����������reducedTaxRate���|����
        if (isReduce)
        {
            return reducedTaxRate * value;
        }

        // return�͕Ԃ��Ƃ����Ӗ��ł���A����GetSalesValue���Ăׂ΁A�v�Z���ʂ�Ԃ��Ă����
        return salesTaxRate * value;
    }
    /// <summary>
    /// �y���ŗ��ŏ��i�̒l�i�ɏ���ł��������̂���Ԃ��i�Q�b�^�[�j
    /// </summary>
    public float GetReducedSalesTaxRate
    {
        get { return reducedTaxRate; }
    }

    /// <summary>
    /// ���N�ی����i2024�N�x�̋��s�̐ŗ��j
    /// </summary>
    private float healthInsurancePremiumRate = 0.1009f;

    /// <summary>
    /// ���ی�����
    /// </summary>
    private float nursingcareInsurancePremiumRate = 0.0182f;

    /// <summary>
    /// �����N���ی�����
    /// </summary>
    private float welfarePensionInsurancePremiumRate = 0.183f;

    /// <summary>
    /// �ٗp�ی������i�J���ҕ��S���j
    /// </summary>
    private float unemploymentInsurancePremiumRate = 0.006f;

    /// <summary>
    /// �x�[�X�ƂȂ鏊���ŗ��i330�`695�j
    /// </summary>
    private float incomeTaxRate = 0.2f;

    /// <summary>
    /// ���z�̎x�����̌v�Z�i�Z���ł͍l�������j
    /// </summary>
    /// <param name="paymentValue"></param>
    /// <returns></returns>
    public float GetMonthlyPayment(float paymentValue)
    {
        float healthInsurancePremium = paymentValue * healthInsurancePremiumRate;

        float nursingcareInsurancePremium = paymentValue * nursingcareInsurancePremiumRate;

        float welfarePensionInsurancePremium = paymentValue * welfarePensionInsurancePremiumRate;

        float unemploymentInsurancePremium = paymentValue * unemploymentInsurancePremiumRate;



        // �T���z
        float dedectionAmount = (paymentValue * 12) * 0.2f + 440000;
        // �N�Ԃ̋��^
        float yearPaymentValue = paymentValue * 12;
        // ���^�z
        float payment = dedectionAmount - yearPaymentValue;
        // �����z
        float incomeTax = (195 * 0.05f + payment * 0.1f) / 12;
        Debug.Log(incomeTax);


        // �����Ɠ����悤�ɁA�i�j�ň͂����������D�悵�Čv�Z�����
        return paymentValue -= (healthInsurancePremium + nursingcareInsurancePremium
            + welfarePensionInsurancePremium + unemploymentInsurancePremium + incomeTax);

    }





    /// <summary>
    /// UnityEngine�Ŏg������s����
    /// �Q�[�����n�܂������ɂP�񂾂����s�����
    /// </summary>
    // Start is called before the first frame update
    private void Start()
    {
        // ���O�ɏ���ł��v�Z���ꂽ��̏��i�̒l�i���o��
        Debug.Log(GetSalesValue(500)); // 550

        // ��������ture��ݒ肵�Ă���̂ŁA�y���ŗ��ł̒l�i���o��
        Debug.Log(GetSalesValue(500, true));

        Debug.Log(GetMonthlyPayment(300000));// 225840

        // BMI���v�Z�B�̏d���g���~�g���Bvar���ł��ł���
        string bmi = ((humanWeight / (humanHight * humanHight)).ToString("F2"));

        //�R�����g�ŏo�́B�g����cm�A�̏d��kg�̕���BMI�́��ł��B
        Debug.Log($"�g��{humanHight * 100}cm�A�̏d{humanWeight}kg�̕���BMI��{bmi}�ł��B");

    }
}
