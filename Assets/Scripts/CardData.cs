/// <summary>
/// :MonoBehaviour���O���ƁAHierarchy����GameObject��AddComponent�ł��Ȃ��Ȃ�
/// �������A�f�[�^�Ƃ��ĉ^�p����ꍇ�͎��s�����͕K�v�Ȃ��̂ł����������`�ɂ���Ɨǂ��ł��B
/// �s�K�v�ȃ��\�b�h����������Ȃ��̂ŃV���v���ȉ^�p���\�ɂȂ�܂��B
/// </summary>

public class CardData
{
    /// <summary>
    /// �g�����v��53�i13*4+1�j�A�ԂŌ�������ID
    /// </summary>
    public int CardId;

    /// <summary>
    /// �X�y�[�h��4�Ȃǂ�4�̕���
    /// </summary>
    public int CardNum;


    /// <summary>
    /// �g�����v�̖�
    /// �N���u��_�C�A�Ȃ�
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
