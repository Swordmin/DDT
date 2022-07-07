using UnityEngine;

public class BootstrapScene : Bootstrap
{
    public static BootstrapScene Bootstrap;
    [SerializeField] private SpawnInitializedService _spawnInitializedService;
    [SerializeField] private SceneFightService _sceneFightService;

    public override void InstallBindings()
    {
        Container.BindInstance(_spawnInitializedService).AsSingle();
        Container.BindInstance(_sceneFightService).AsSingle();
    }
}