using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HandVizualizer))]

public class PlayerHand : Hand
{
    [SerializeField] private Vector2 _touchPostition;
    [SerializeField] private float _damage; //TODO
    [SerializeField] private TextEngine _textEngine;
    public event System.Action<float> OnWin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnemyHand hand)) 
        {
            if (Fight(hand) == FightResultType.Lose) Lose(hand);
            if (Fight(hand) == FightResultType.Win) Win(hand);
        }
    }

    private void Update()
    {
        _touchPostition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var moveY = _touchPostition.y;
        moveY = Mathf.Clamp(moveY, -4.5f, -0.5f);
        var moveX = _touchPostition.x;
        moveX = Mathf.Clamp(moveX, -10f, -5f);
        transform.DOMove(new Vector2(moveX, moveY), 0.2f);
    }

    private void Lose(EnemyHand hand) 
    {


    }

    private void Win(EnemyHand hand) 
    {
        _damage = Random.Range(1, 10);
        OnWin?.Invoke(_damage);
        TextEngine text = Instantiate(_textEngine, transform.position, Quaternion.identity);
        text.Draw($"{_damage}", Color.white, new Vector2(SceneFightEngine.Engine.PlayerBody.transform.position.x, SceneFightEngine.Engine.PlayerBody.transform.position.y + 1));
        hand.Lose();
    }

}
