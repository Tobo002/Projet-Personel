using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 20;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log(enemy.name);
            enemy.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
