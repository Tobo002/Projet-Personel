using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public float force = 500f;
    public float radius = 5f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Rigidbody2D player = collision.collider.GetComponent<Rigidbody2D>();
            Rigidbody2D self = GetComponent<Rigidbody2D>();
            Vector2 dir = player.position - self.position;
            player.AddForce(dir.normalized * force);
            self.AddForce(dir.normalized * -force);
        }
    }
}
