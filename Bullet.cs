using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 10;
    public int delete = 5;

    void Start()
    {
        rb.velocity = transform.up * speed;
        Invoke(nameof(bonk), delete);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log(enemy.name);
            enemy.takeDamage(damage);
        }
        CancelInvoke(nameof(bonk));
        bonk();
    }

    void bonk()
    {
        Destroy(gameObject);
    }
}
