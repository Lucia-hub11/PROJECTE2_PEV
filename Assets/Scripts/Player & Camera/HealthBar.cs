using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider _mySlider;
    Image _fillImage;

    void Start()
    {
        _mySlider = GetComponent<Slider>();
        _mySlider.value = 1;
        _fillImage = _mySlider.fillRect.GetComponent<Image>();
        PlayerHealth.OnDamage += Redraw;
       /* PlayerHealth.OnHeal += Redraw; */
    }

    private void Redraw(float value)
    {
        _mySlider.value = value;
        HealthBarColor(value);
    }

    private void HealthBarColor(float healthPercentage)
    {
        Color healthColor;
        Color red = Color.red;
        Color yellow = Color.yellow;
        Color green = Color.green;
        if (healthPercentage > 0.5f)
        {
            healthColor = Color.Lerp(yellow, green, (healthPercentage - 0.5f) * 2);
        }
        else
        {
            healthColor = Color.Lerp(red, yellow, healthPercentage * 2);
        }
        _fillImage.color = healthColor;
    }
}