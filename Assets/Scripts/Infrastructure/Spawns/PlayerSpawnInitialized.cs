using UnityEngine;

public class PlayerSpawnInitialized : SpawnInitialized
{
    [SerializeField] private PlayerBody _playerPrefab;

    public override void Initialized()
    {
        PlayerBody body = Instantiate(_playerPrefab, transform.position, Quaternion.identity);
        body.Initialized();
    }
    private void Start()
    {
        AllSceneServices.SceneServices.GetService<SpawnInitializedService>().AddSpawn(this);
    }
}