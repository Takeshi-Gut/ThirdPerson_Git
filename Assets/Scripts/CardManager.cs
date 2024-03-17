using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    /// <summary>
    /// CardDataの配列を作成します。
    /// 配列とは、データの集まりのことです。
    /// 今回は単純に一次元の配列を使います。
    /// イメージとしてはトランプの一枚一枚の情報53枚分を
    /// ※※ハイアンドローはジョーカーなしなので52枚にします
    /// 一括で処理できる変数と思ってください。
    /// </summary>
    private CardData[] cardDatas = new CardData[52];


    // Start is called before the first frame update
    void Start()
    {
        // for文は第一引数(int i)から第二引数(cardDatas.lengthはcardDatasの総数)になるまで、
        // 第三引数の操作を行ないます。
        // ざっくりいうと、任意の数まで繰り返しを行ないたい時に使用します。
        for (int i = 0; i < cardDatas.Length; i++)
        // 0がスタートなので、0から52までの配列です！総数53個の配列
        {
            // まずidだけを指定した空のCardDataをnewで作成します。
            // iの数ですが、一週目は0,二週目は1,三週目は2と増えていきます。
            // 下のコードが何をしているかというと、cardDataの0番目（一番最初）のデータを
            // iDを除いて初期状態で作成しています。
            cardDatas[i] = new CardData(CardSuitJudge(i), CardNumJudge(i), i);

            // このiという値を使ってSuitとCardNumを決定したいと思います。

            Debug.Log($"このカードのデータは" +
                $"{cardDatas[i].CardSuit}の" +
                $"{cardDatas[i].CardNum}");
        }
    }

    /// <summary>
    /// 外部からランダムにCardDataを取得するためのメソッド
    /// </summary>
    /// <returns></returns>
    public CardData GetCardData()
    {
        // Random.Range(int min, int max)でmaxまでの値をランダムに取得できます。
        // intで指定した場合は、maxの値は入らないので+1をすると良いです。
        return cardDatas[Random.Range(0, cardDatas.Length)];
    }




    /// <summary>
    /// CardData.Suitsを、引数によって計算して返すメソッド
    /// 例えば第一引数が0の場合、0を13で割っても0なので
    /// CardData.SuitsはClubとなります。
    /// または第一引数が15の場合、15を13で割ったら1余り2となります。
    /// int型の場合は余りは無視されるので1という値が残ります。
    /// それをCardData.SuitsにキャストするとDiaとなります。
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public CardData.Suits CardSuitJudge(int num)
    {
        // 型を他の型に変換することをCastといいます。
        // int型にCardData.Suits.MaxをCastすると、4となります。
        for (int i = 0; i < (int)CardData.Suits.Max; i++) // Max
        {
            if (num / 13 == i)
            {
                return (CardData.Suits)i; // CardData.csのSuits型で変換
            }
        }
        return CardData.Suits.Invalid;
    }

    // public修飾子でint型を返すCardNumJudge(int num)というメソッドを作成してください。
    // メソッドの中身はfor文を使い、int iが13になるまで、繰り返しの処理を行ないます。

    public int CardNumJudge(int num)
    {
        for (int i = 0; i < 13; i++)
        {
            // for文の中身はもし、引数のnumを13で割った余りが、iとイコールの関係であれば、
            if (num % 13 == i)
            {
                // iに1を足したものをreturnします。
                return i + 1;
            }
        }
        // for文を過ぎた後はreturn 0を返してください。
        return 0;
    }
}
