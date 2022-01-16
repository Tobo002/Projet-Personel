using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public Slider slider;
    public Image bar;
    public Image fella;
    public Gradient grad;

    void Start()
    {
        currentHealth = PlayerPrefs.GetInt("Health", maxHealth);
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
        bar.color = grad.Evaluate(slider.normalizedValue);
        fella.color = grad.Evaluate(slider.normalizedValue);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        slider.value = currentHealth;
        bar.color = grad.Evaluate(slider.normalizedValue);
        fella.color = grad.Evaluate(slider.normalizedValue);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerPrefs.DeleteKey("Health");
        SceneManager.LoadScene("Dead");
    }

}
