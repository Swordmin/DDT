using UnityEngine;

public class FightField : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] AssetEnemy _data;

    public void StartFight() 
    {
        _spawner.UpdateCooldown(_data.AtackCooldown);
        _spawner.UpdateTime(_data.AtackTime);
        _spawner.StartSpawn();
    }

    public void UpdateData(AssetEnemy data)
    {
        _data = data;
    }

}
