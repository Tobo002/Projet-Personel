using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGate : MonoBehaviour
{

    private Vector2 entryForce = new Vector2(1000, 500);
    public GameObject[] enemies;
    public bool inRoom;
    private Vector3 spawnOffset = new Vector3(3, 0, 0);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) {
            collision.GetComponent<Rigidbody2D>().AddForce(entryForce);
            collision.GetComponent<PlayerMovement>().enabled = false;
            Invoke(nameof(LevelStart), 0.5f);
        }
    }

    private void Update()
    {
        bool allDead = true;

        foreach(GameObject obj in enemies)
        {
            if(obj != null)
            {
                allDead = false;
            }
        }

        if (allDead && inRoom)
        {
            AllDone();
        }
    }

    private void LevelStart()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;

        inRoom = true;

        GameObject[] gates = GameObject.FindGameObjectsWithTag("Gate");

        foreach (GameObject gate in gates)
        {
            BoxCollider2D collider = gate.GetComponent<BoxCollider2D>();
            collider.offset = new Vector2(0, 0);
            collider.size = new Vector2(0.32f, 0.32f);
            collider.isTrigger = false;
            gate.GetComponent<SpriteRenderer>().enabled = true;
        }

        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyAI>().enabled = true;
        }
    }

    private void AllDone()
    {
        GameObject[] gates = GameObject.FindGameObjectsWithTag("Gate");

        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<SpriteRenderer>().enabled = false;

        foreach (GameObject gate in gates)
        {
            BoxCollider2D collider = gate.GetComponent<BoxCollider2D>();
            collider.offset = new Vector2(0.08f, 0);
            collider.size = new Vector2(0.16f, 0.32f);
            collider.isTrigger = true;
            gate.GetComponent<SpriteRenderer>().enabled = false;
        }
        Destroy(this);
    }
}