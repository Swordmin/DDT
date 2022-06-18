using UnityEngine;

public class PlayerEngine : MonoBehaviour
{

    [SerializeField] private PlayerHand _hand;
    [SerializeField] private PlayerBody _body;

    private void Awake()
    {
        _hand.OnWin.AddListener(AddDamage);
    }

    private void AddDamage(float damage) 
    {
        _body.Damage += damage;
    }

}
