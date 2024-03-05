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
        if (!spawned)
        {
            GameObject toSpawn = null;
            switch (openingDirection)
            {
                case 1:
                    toSpawn = templates.bottomRooms[Random.Range(0, templates.bottomRooms.Length)];
                    break;
                case 2:
                    toSpawn = templates.topRooms[Random.Range(0, templates.topRooms.Length)];
                    break;
                case 3:
                    toSpawn = templates.leftRooms[Random.Range(0, templates.leftRooms.Length)];
                    break;
                case 4:
                    toSpawn = templates.rightRooms[Random.Range(0, templates.rightRooms.Length)];
                    break;
            }

            if (toSpawn != null)
            {
                // Instantiate as child of a new, correctly positioned GameObject
                GameObject roomParent = new GameObject("RoomParent");
                roomParent.transform.position = transform.position; // Set the parent's position to the spawner's position
                Instantiate(toSpawn, roomParent.transform);
            }

            spawned = true;
        }
    }

}
