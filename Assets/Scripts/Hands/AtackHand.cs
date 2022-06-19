using System;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(HandVizualizer))]
public class AtackHand : Hand, IHealth
{

    [SerializeField] private float _damage;
    [SerializeField] private TextEngine _text;
    [SerializeField] private float _speed;

    public void DamageClear()
    {
        _damage = 0;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException("Value must be positive");
        _damage -= damage;
        if (_damage <= 0)
        {
            Die();
            return;
        }

        TextEngine text = Instantiate(_text, transform.position, Quaternion.identity);
        text.Draw($"-{damage}", Color.white, new Vector2(transform.position.x + 1, transform.position.y + 1), 2, 1.5f, 1.5f);

    }

    public void SetDamage(float damage) 
    {
        _damage = damage;
    }

    public void Atack(Transform target)
    {            
        transform.DOLocalMove(target.position, _speed).SetEase(Ease.Linear);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IHealth health)) 
        {
            health.TakeDamage(_damage);
        }
        if(collision.GetComponent<EnemyBody>() || collision.GetComponent<PlayerBody>()) 
        {
            Destroy(gameObject);
        }
    }

}
