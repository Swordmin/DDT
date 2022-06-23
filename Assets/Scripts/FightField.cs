using System;
using UnityEngine;

public class FightField : Service
{
    [SerializeField] private FieldSpawner _fieldSpawner;
    [SerializeField] private AssetEnemy _data;
    [SerializeField] private Transform _playerHandSpawnPosition;

    protected override void Register()
    {
        AllSceneServices.SceneServices.RegisterService(this);
    }

    private void Awake()
    {
        Register();
    }

    public void InitializedHand(PlayerHand hand, out  PlayerHand handSpawn)
    {
        handSpawn = Instantiate(hand, _playerHandSpawnPosition.position, hand.transform.rotation);
    }
    
    public void StartFight() 
    {
        _fieldSpawner.UpdateCooldown(_data.AtackCooldown);
        _fieldSpawner.UpdateTime(_data.AtackTime);
        _fieldSpawner.StartSpawn();
    }

    public void UpdateData(AssetEnemy data)
    {
        _data = data;
    }

}
