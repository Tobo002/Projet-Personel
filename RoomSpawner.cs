using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    public int roomCount = 4;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke(nameof(Spawn), 0.1f);
    }

    void Spawn()
    {
        if (!spawned && templates.i < roomCount)
        {
            rand = Random.Range(0, templates.rooms.Length);
            Instantiate(templates.rooms[rand], transform.position, templates.rooms[rand].transform.rotation);
            spawned = true;
            templates.i += 1;
        }else if (!spawned)
        {
            Instantiate(templates.exit, transform.position, templates.exit.transform.rotation);
            Instantiate(templates.grid);
        }
    }
    
}
