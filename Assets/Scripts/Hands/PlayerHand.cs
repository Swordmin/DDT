using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(HandVizualizer))]

public class PlayerHand : Hand
{
    [SerializeField] private Vector2 _touchPostition;
    [SerializeField] private float _damage; 
    [SerializeField] private TextEngine _textEngine;
    private SceneFightService _fightService;
    public event System.Action<float> OnWin;

    private void Start()
    {
        _fightService = AllSceneServices.SceneServices.GetService<SceneFightService>();
    }

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
        text.Draw($"{_damage}", Color.white, new Vector2(_fightService.PlayerBody.transform.position.x, _fightService.PlayerBody.transform.position.y + 1));
        hand.Lose();
    }

}
