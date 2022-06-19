using UnityEngine;


[CreateAssetMenu(menuName ="Enemy")]
public class AssetEnemy : ScriptableObject
{

    [SerializeField] private string _name;
    public string Name => _name;

    [SerializeField] private float _maxHealth;
    public float MaxHealth => _maxHealth;

    [SerializeField] private float _atackTime;
    public float AtackTime => _atackTime;

    [SerializeField] private float _atackCooldown;
    public float AtackCooldown => _atackCooldown;

    [SerializeField] private HandType _favoriteHand;
    public HandType FavoriteHand => _favoriteHand;





}
