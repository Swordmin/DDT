using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(HandVizualizer))]
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyHand : Hand
{
    private BoxCollider2D _collider;
    [HideInInspector] public UnityEvent OnDie;
    private Spawner _spawner;

    private void OnEnable()
    {
        SetRandomType();
    }

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        _spawner.OnSpawnEnd += Lose;
        transform.DOLocalMoveX(-15, 5).SetEase(Ease.Linear).OnComplete(() =>
        {
            OnDie?.Invoke();
            Destroy(gameObject);
        });
    }

    private void OnDestroy()
    {
        _spawner.OnSpawnEnd -= Lose;
    }

    public void UpdateSpawner(Spawner spawner) => _spawner = spawner;

    public void Lose() 
    {
        _collider.enabled = false;
        float scale = Random.Range(1.2f, 1.8f);
        transform.DOScale(new Vector3(scale, scale, scale), 0.1f);
        transform.DOLocalMoveY(-15, 0.5f).SetEase(Ease.InExpo);
        transform.DORotate(new Vector3(0, 0, 90), 0.5f).SetLoops(10);
        OnDie?.Invoke();
        Destroy(gameObject, 5);
    }

}