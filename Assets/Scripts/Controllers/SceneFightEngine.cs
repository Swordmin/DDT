using UnityEngine;

public class SceneFightEngine : MonoBehaviour
{
    public static SceneFightEngine Engine;
    public PlayerBody PlayerBody;
    public EnemyBody CurrentEnemyBody;
    [SerializeField] private FightField _field;

    private void Awake()
    {
        if (!Engine)
            Engine = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartFight();
    }

    public void UpdateEnemy(EnemyBody enemy)
    {
        CurrentEnemyBody = enemy;
    }

    public void AddPlayerDamage(float damage)
    {
        PlayerBody.Damage += damage;
    }

    private void StartFight()
    {
        _field.UpdateData(CurrentEnemyBody.Data);
        _field.StartFight();
    }

    public void EndFight() 
    {
        PlayerBody.Atack(CurrentEnemyBody);
        PlayerBody.DamageClear();
    }

}
