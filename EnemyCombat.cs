using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public float force = 500f;
    public float radius = 5f;
    public int damage = 10;
    public GameObject blood;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Rigidbody2D playerRb = collision.collider.GetComponent<Rigidbody2D>();
            Rigidbody2D self = GetComponent<Rigidbody2D>();
            Vector2 dir = playerRb.position - self.position;
            playerRb.AddForce(dir.normalized * force);
            self.AddForce(dir.normalized * -force);
            collision.collider.GetComponent<Player>().takeDamage(damage);
            Instantiate(blood, new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y, -1), blood.transform.rotation);
        }
    }
}
