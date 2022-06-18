using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Body : MonoBehaviour
{

    [SerializeField] private float _maxHealth, _currentHealth;
    [SerializeField] private float _damage;

    public UnityEvent<float, float> OnHealthChange;

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
            Die();
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
        body.TakeDamage(Damage);
    }



}
