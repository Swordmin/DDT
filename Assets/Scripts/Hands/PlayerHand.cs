using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(HandVizualizer))]

public class PlayerHand : Hand
{
    public event System.Action<float> OnWin;
    
    [SerializeField] private Vector2 _touchPostition; 
    [SerializeField] private float _damage;
    [SerializeField] private TextEngine _textEngine;

    [Header("Move area"), Space(10)]
    [SerializeField,Range(-10,10)]private float _clampXMin;
    [SerializeField,Range(-10,10)]private float _clampXMax;
    [SerializeField,Range(-10,10)] private float _clampYMin;
    [SerializeField,Range(-10,10)]private float _clampYMax;
    
    private SceneFightService _fightService;
    
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
        HandMove();
    }

    private void HandMove()
    {
        _touchPostition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float moveY = _touchPostition.y;
        moveY = Mathf.Clamp(moveY, _clampYMin, _clampYMax);
        float moveX = _touchPostition.x;
        moveX = Mathf.Clamp(moveX, _clampXMin, _clampXMax);
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
