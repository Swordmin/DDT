using UnityEngine;

public class SceneFightService : Service
{
    public PlayerBody PlayerBody;
    public EnemyBody CurrentEnemyBody;
    [SerializeField] private FightField _field;

    protected override void Register()
    {
        AllSceneServices.SceneServices.RegisterService(this);
    }

    private void Awake()
    {
        Register();
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

    public void EndFight()
    {
        PlayerBody.Atack(CurrentEnemyBody);
        CurrentEnemyBody.Atack(PlayerBody);
        PlayerBody.DamageClear();
    }

    private void StartFight()
    {
        _field.UpdateData(CurrentEnemyBody.Data);
        _field.StartFight();
    }
}