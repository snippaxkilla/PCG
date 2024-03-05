using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public int mapWidth = 64;
    public int mapHeight = 64;
    public GameObject roomPrefab;

    private List<Vector2> roomPositions = new List<Vector2>();

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        roomPositions.Clear();
        // Starting position for the dungeon
        Vector2 currentPos = new Vector2(mapWidth / 2, mapHeight / 2);
        roomPositions.Add(currentPos);

        int numberOfRooms = Random.Range(10, 20); // Randomize the number of rooms

        for (int i = 0; i < numberOfRooms; i++)
        {
            Vector2 newPos = currentPos;
            switch (Random.Range(0, 4)) // 0: up, 1: right, 2: down, 3: left
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
                Instantiate(roomPrefab, new Vector3(newPos.x, newPos.y, 0), Quaternion.identity);
            }
        }
    }

    bool IsValidPosition(Vector2 newPos)
    {
        if (newPos.x < 0 || newPos.x >= mapWidth || newPos.y < 0 || newPos.y >= mapHeight)
        {
            return false; // New position is outside the dungeon bounds
        }
        if (roomPositions.Contains(newPos))
        {
            return false; // A room already exists at the new position
        }
        return true;
    }
}
