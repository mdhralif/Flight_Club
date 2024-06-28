using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBAr : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    void Start()
    {
        slider.value = 100;
        slider.maxValue = 100;
    }
    public void setMaxHealth(int maxHealth)
    {
        slider.value = maxHealth;
        slider.maxValue = maxHealth;
        fill.color = gradient.Evaluate(1f);

    }
    public void setHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
