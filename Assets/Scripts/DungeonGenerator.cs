using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public int mapWidth = 64;
    public int mapHeight = 64;
    public GameObject[] roomPrefabs;

    private List<Vector2> roomPositions = new List<Vector2>();

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        roomPositions.Clear();
        Vector2 currentPos = Vector2.zero; 
        roomPositions.Add(currentPos);
        CreateRoomAtPosition(currentPos); 

        int numberOfRooms = Random.Range(200, 1000); 

        for (int i = 0; i < numberOfRooms; i++)
        {
            Vector2 newPos = currentPos;
            switch (Random.Range(0, 4))
            {
                case 0:
                    newPos += Vector2.up;
                    break;
                case 1:
                    newPos += Vector2.right;
                    break;
                case 2:
                    newPos += Vector2.down;
                    break;
                case 3:
                    newPos += Vector2.left;
                    break;
            }

            if (IsValidPosition(newPos))
            {
                roomPositions.Add(newPos);
                currentPos = newPos;
                CreateRoomAtPosition(newPos); 
            }
        }
    }

    void CreateRoomAtPosition(Vector2 position)
    {
        GameObject roomPrefab = roomPrefabs[Random.Range(0, roomPrefabs.Length)];     
        Instantiate(roomPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
    }

    bool IsValidPosition(Vector2 newPos)
    {
        if (newPos.x < 0 || newPos.x >= mapWidth || newPos.y < 0 || newPos.y >= mapHeight)
        {
            return false; 
        }
        if (roomPositions.Contains(newPos))
        {
            return false; 
        }
        return true;
    }
}
