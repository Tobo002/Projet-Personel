using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public Slider slider;
    public Image bar;
    public Gradient grad;

    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        bar.color = grad.Evaluate(1f);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;
        bar.color = grad.Evaluate(slider.normalizedValue);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("L ratio");
        Destroy(this.gameObject);
    }
}
