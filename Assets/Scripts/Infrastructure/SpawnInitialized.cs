using UnityEngine;

public abstract class SpawnInitialized : MonoBehaviour
{
    [SerializeField] protected GameObject _prefab;
    [SerializeField] protected Transform _tramsformSpawn;

    public virtual void Initialized()
    {
        GameObject instanceObject = Instantiate(_prefab, _tramsformSpawn.position, Quaternion.identity);
    }
}