using System;
using UnityEngine;

public abstract class Body : MonoBehaviour, IHealth
{

    [SerializeField] protected float _maxHealth, _currentHealth;
    [SerializeField] protected float _damage;
    [SerializeField] protected AtackHand _atackHand;

    public event Action<float, float> OnHealthChange;

    public float Damage 
    {
        get { return _damage; }
        set 
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Value must be positive");
            _damage = value;
        }
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        OnHealthChange?.Invoke(_currentHealth, _maxHealth);
    }

    public virtual void TakeDamage(float damage) 
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException("Value must be positive");
        _currentHealth -= damage;
        if (_maxHealth <= 0)
        {
            Die();
        }

        OnHealthChange?.Invoke(_currentHealth, _maxHealth);
    }

    public void Die() 
    {
    
    }

    public void DamageClear() 
    {
        Damage = 0;
    }

    public void Atack(Body body) 
    {
        Vector2 instantiatePostition;
        if (body.transform.position.x < transform.position.x)
            instantiatePostition = new Vector2(transform.position.x - 1, transform.position.y);
        else
            instantiatePostition = new Vector2(transform.position.x + 1, transform.position.y);
        
        AtackHand hand = Instantiate(_atackHand, instantiatePostition, _atackHand.transform.rotation);
        
        InitializedAtackHand(body, hand);
    }

    protected void SetDamage(float damage)
    {
        _damage = damage;
    }

    protected void SetMaxHealth(float health) => _maxHealth = health;

    private void InitializedAtackHand(Body body, AtackHand hand)
    {
        hand.Initialized(HandType.Paper);
        hand.SetDamage(_damage);
        hand.Atack(body.transform);
    }
}
