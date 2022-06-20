using UnityEngine;

public class PlayerEngine : MonoBehaviour
{

    [SerializeField] private PlayerHand _hand;
    [SerializeField] private PlayerBody _body;

    private void Awake()
    {
        _hand.OnWin += AddDamage;
    }

    private void OnDestroy()
    {
        _hand.OnWin -= AddDamage;
    }

    private void AddDamage(float damage) 
    {
        _body.Damage += damage;
    }

}
