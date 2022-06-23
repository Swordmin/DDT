using System;
using UnityEngine;

public class EnemySpawnInitialized : SpawnInitialized
{
    [SerializeField] private AssetEnemy _data;
    [SerializeField] private EnemyBody _enemyPrefab;

    private void OnEnable()
    {
        AllSceneServices.SceneServices.GetService<SpawnInitializedService>().AddSpawn(this);
    }

    public override void Initialized()
    {
        EnemyBody body = Instantiate(_enemyPrefab, _tramsformSpawn.position, Quaternion.identity);
        body.Initialized(_data);
    }
}