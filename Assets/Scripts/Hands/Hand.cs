using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private HandType _type;
    public HandType Type => _type;

    public void Initialized(HandType type)
    {
        _type = type;
    }

    public FightResultType Fight(Hand hand)
    {
        if (hand.Type == Type) return FightResultType.Draw;

        switch (Type)
        {
            case HandType.Paper:
                if (hand.Type == HandType.Stone) return FightResultType.Win;
                if (hand.Type == HandType.Scissors) return FightResultType.Lose;
                break;
            case HandType.Scissors:
                if (hand.Type == HandType.Paper) return FightResultType.Win;
                if (hand.Type == HandType.Stone) return FightResultType.Lose;
                break;
            case HandType.Stone:
                if (hand.Type == HandType.Scissors) return FightResultType.Win;
                if (hand.Type == HandType.Paper) return FightResultType.Lose;
                break;
        }

        return FightResultType.Draw;
    }

    public void SetRandomType()
    {
        int enumId = UnityEngine.Random.Range(0, 4);
        _type = (HandType)enumId;
    }
}