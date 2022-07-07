﻿using System;
using UnityEngine;
using Zenject;

public class EnemyBody : Body
{
    [SerializeField] private AssetEnemy _data;
    [SerializeField] private TextEngine _text;
    [SerializeField] private SceneFightService _fightService;
    public AssetEnemy Data => _data;

    [Inject]
    private void Constructor(SceneFightService fightService)
    {
        _fightService = fightService;
    }
    public void Initialized(AssetEnemy data)
    {
        _data = data;
        SetMaxHealth(_data.MaxHealth);
        SetDamage(data.Damage);
        if(!_fightService.CurrentEnemyBody)
            _fightService.UpdateEnemy(this);
    }
    

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        TextEngine text = Instantiate(_text, transform.position, Quaternion.identity);
        text.Draw($"-{damage}", Color.white, new Vector2(transform.position.x + 1, transform.position.y + 1), 2, 1.5f , 1.5f);
    }
}

