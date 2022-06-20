using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Body _body;
    [SerializeField] private Image _image;
    [SerializeField] float _duration = 1;
    private void Awake()
    {
        _body.OnHealthChange += UpdateBar;
    }

    private void OnDestroy()
    {
        _body.OnHealthChange -= UpdateBar;
    }

    private void UpdateBar(float currentHealth, float maxHealth) 
    {
        float currentValue = currentHealth / maxHealth;
        StartCoroutine(HealthBarChange(currentValue, _duration));
        _text.text = $"{currentHealth}/{maxHealth}";
    }

    private IEnumerator HealthBarChange(float currentValue, float duration) 
    {
        float time = 0;
        while (time < duration) 
        {
            _image.fillAmount = Mathf.Lerp(_image.fillAmount, currentValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }

}
