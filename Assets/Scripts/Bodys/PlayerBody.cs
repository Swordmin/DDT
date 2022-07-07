using UnityEngine;
using Zenject;

public class PlayerBody : Body
{
    [SerializeField] private SceneFightService _fightService;

    [Inject]
    private void Constructor(SceneFightService fightService)
    {
        _fightService = fightService;
    }
    
    public void Initialized()
    {
        _fightService.PlayerBody = this;
    }
}