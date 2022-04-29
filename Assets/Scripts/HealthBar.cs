using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image image;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        image.color = gradient.Evaluate(1);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        image.color = gradient.Evaluate(slider.normalizedValue);
    }
}
