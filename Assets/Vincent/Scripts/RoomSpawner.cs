using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openingDirection;
    // 1 = Bottom room
    // 2 = Top room
    // 3 = Left room 
    // 4 = Right Room 

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.25f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1) // spawn bottom room
            {
                var rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2) // spawn top room
            {
                var rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3) // spawn left room
            {
                var rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4) // spawn right room
            {
                var rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned == true)
        {
            Destroy(gameObject);
        }
        
    }

}
