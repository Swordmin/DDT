using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FieldSpawner : MonoBehaviour
{
    public event Action OnSpawnEnd;

    [SerializeField] private EnemyHand _spawnObject;

    [SerializeField] private float _sizeX;
    [SerializeField] private float _sizeY;

    [SerializeField] private int _count;
    [SerializeField] private float _time;
    [SerializeField] private float _cooldown;
    [SerializeField] private bool _endlessly;
    [SerializeField] private bool _playOnAwake;

    [SerializeField] private bool _spawn;
    [SerializeField] private List<EnemyHand> _hands;

    private SceneFightService _fightService;


    private void Awake()
    {
        if (_playOnAwake)
        {
            _spawn = true;
            StartCoroutine(SpawnTick());
        }
    }

    private void Start()
    {
        _fightService = AllSceneServices.SceneServices.GetService<SceneFightService>();
        OnSpawnEnd += _fightService.EndFight;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, new Vector3(_sizeX * 2, _sizeY * 2));
    }

    private void OnDestroy()
    {
        OnSpawnEnd -= _fightService.EndFight;
    }

    public void UpdateTime(float time) => _time = time;
    public void UpdateCooldown(float cooldown) => _cooldown = cooldown;

    public void StartSpawn()
    {
        _spawn = true;
        StartCoroutine(SpawnTick());
    }

    public void StopSpawn()
    {
        _spawn = false;
        _hands.Clear();
    }


    private void Spawn()
    {
        float x = Random.Range(transform.position.x - _sizeX, transform.position.x + _sizeX);
        float y = Random.Range(transform.position.y - _sizeY, transform.position.y + _sizeY);
        EnemyHand handSpawn = Instantiate(_spawnObject, new Vector2(x, y), Quaternion.identity);
        _hands.Add(handSpawn);
        handSpawn.UpdateSpawner(this);
        handSpawn.OnDie.AddListener(() => _hands.Remove(handSpawn));
    }

    private IEnumerator SpawnTick()
    {
        if (_endlessly)
            while (_spawn)
            {
                Spawn();
                yield return new WaitForSeconds(_cooldown);
            }
        else
        {
            StartCoroutine(SpawnTimer());
            while (_spawn)
            {
                Spawn();
                yield return new WaitForSeconds(_cooldown);
            }
        }
    }

    private IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(_time);
        OnSpawnEnd?.Invoke();
        StopSpawn();
    }
}