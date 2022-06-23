using System;
using System.Collections.Generic;
using UnityEngine;


public class SpawnInitializedService : Service
{
    [SerializeField] private List<SpawnInitialized> _spawns;

    protected override void Register()
    {
        AllSceneServices.SceneServices.RegisterService(this);
    }
    
    private void Awake()
    {
        Register();
    }

    public void Enter()
    {
        foreach (SpawnInitialized spawn in _spawns)
        {
            spawn.Initialized();
        }
    }

    public void AddSpawn(SpawnInitialized spawn)
    {
        _spawns.Add(spawn);
    }

    private void Start()
    {
        Enter();
    }
}
