using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("L ratio");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        this.enabled = false;
    }
}
