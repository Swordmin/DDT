using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class HandVizualizer : MonoBehaviour
{
    private Hand _hand;
    private SpriteRenderer _sprite;

    private const string _paper = "Sprites/Paper";
    private const string _scissor = "Sprites/Scissor";
    private const string _stone = "Sprites/Stone";

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _hand = GetComponent<Hand>();

        switch (_hand.Type) 
        {
            case HandType.Paper:
                _sprite.sprite = Resources.Load<Sprite>(_paper);
                break;
            case HandType.Scissors:
                _sprite.sprite = Resources.Load<Sprite>(_scissor);
                break;
            case HandType.Stone:
                _sprite.sprite = Resources.Load<Sprite>(_stone);
                break;
        }

    }

}
