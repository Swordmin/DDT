using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class HandVizualizer : MonoBehaviour
{
    private Hand _hand;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _hand = GetComponent<Hand>();

        switch (_hand.Type) 
        {
            case HandType.Paper:
                _sprite.sprite = Resources.Load<Sprite>("Sprites/Paper");
                break;
            case HandType.Scissors:
                _sprite.sprite = Resources.Load<Sprite>("Sprites/Scissors");
                break;
            case HandType.Stone:
                _sprite.sprite = Resources.Load<Sprite>("Sprites/Stone");
                break;
        }

    }

}
