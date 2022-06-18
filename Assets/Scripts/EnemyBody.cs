using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : Body
{
    [SerializeField] private AssetEnemy _data;
    [SerializeField] private TextEngine _textEngine;
    public AssetEnemy Data => _data;

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        TextEngine text = Instantiate(_textEngine, transform.position, Quaternion.identity);
        text.Draw(damage.ToString(), Color.white, new Vector2(transform.position.x + 1, transform.position.y + 1), 2, 1.5f , 1.5f);

    }
}

