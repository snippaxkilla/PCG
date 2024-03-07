using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    private RoomTemplates templates;
    private bool spawned = false;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint") && collision.GetComponent<RoomSpawner>().spawned == true)
        {
            Destroy(gameObject);
        }
    }

    private void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                // Need to spawn a room with a TOP door
                Instantiate(templates.topRooms[Random.Range(0, templates.topRooms.Length)], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 2)
            {
                // Need to spawn a room with a BOTTOM door
                Instantiate(templates.bottomRooms[Random.Range(0, templates.bottomRooms.Length)], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 3)
            {
                // Need to spawn a room with a RIGHT door
                Instantiate(templates.rightRooms[Random.Range(0, templates.rightRooms.Length)], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                // Need to spawn a room with a LEFT door
                Instantiate(templates.leftRooms[Random.Range(0, templates.leftRooms.Length)], transform.position, Quaternion.identity);
            }
            spawned = true;
        }
    }
}