/// <summary>
/// :MonoBehaviourを外すと、Hierarchy欄でGameObjectにAddComponentできなくなる
/// しかし、データとして運用する場合は実行処理は必要ないのでこういった形にすると良いです。
/// 不必要なメソッドも実装されないのでシンプルな運用が可能になります。
/// </summary>

public class CardData
{
    /// <summary>
    /// トランプを53（13*4+1）連番で見た時のID
    /// </summary>
    public int CardId;

    /// <summary>
    /// スペードの4などの4の部分
    /// </summary>
    public int CardNum;


    /// <summary>
    /// トランプの役物
    /// クラブやダイアなど
    /// </summary>
    public enum Suits
    {
        Invalid = -1,
        Club,
        Dia,
        Heart,
        Spade,
        Max
    };

    public Suits CardSuit = Suits.Invalid;

    public CardData(Suits suit, int number, int id)
    {
        CardSuit = suit;
        CardNum = number;
        CardId = id;
    }
}
