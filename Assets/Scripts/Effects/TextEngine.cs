using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(TextMeshPro))]
public class TextEngine : MonoBehaviour
{

    [SerializeField] private TextMeshPro _textMesh;
    [SerializeField] private Vector2 _target;
    [SerializeField] private float _value;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _fadeSpeed;
    [SerializeField] private float _destroyTime = 0.1f;
    private Sequence _sequence;

    private void Awake()
    {
        _sequence = DOTween.Sequence();
        _textMesh = GetComponent<TextMeshPro>();
    }

    public void Draw(string text, Color color, Vector2 target) 
    {
        _textMesh.text = text;
        _textMesh.color = color;
        _target = target;
        Move();
    }
    public void Draw(string text, Color color, Vector2 target, float speed, float fadeSpeed,float destroyTime)
    {
        _textMesh.text = text;
        _textMesh.color = color;
        _target = target;
        _speed = speed;
        _destroyTime = destroyTime;
        _fadeSpeed = fadeSpeed;
        Move();
    }
    public void Draw(string text, Color color, Vector2 target, float value)
    {
        _textMesh.text = text;
        _textMesh.color = color;
        _target = target;
        _value = value;
        Move();
    }

    private void Move() 
    {
        transform.DOScale(new Vector2(0.08f, 0.13f), _speed);
        transform.DORotate(new Vector3(0, 0, Random.Range(-10, 10)), _speed);
        Color currentColor = _textMesh.color;
        if(_fadeSpeed != 0)
            _textMesh.DOColor(new Color(currentColor.a, currentColor.b, currentColor.r, 0), _fadeSpeed).SetEase(Ease.InExpo);
        _sequence.Append(transform.DOMove(_target, 1).SetEase(Ease.InExpo));
        _sequence.AppendCallback(() => Destroy(gameObject, _destroyTime));
    }

}
