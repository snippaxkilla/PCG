using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    
    void Start()
    {
        
    }

    void Update()
    {
        if (openingDirection == 1) 
        {
            // Need to spawn a room with a BOTTOM door
            // Need to spawn a room with a TOP door
        }
        else if (openingDirection == 2)
        {
            // Need to spawn a room with a LEFT door
            // Need to spawn a room with a RIGHT door
        }
        else if (openingDirection == 3)
        {
            // Need to spawn a room with a TOP door
            // Need to spawn a room with a RIGHT door
        }
        else if (openingDirection == 4)
        {
            // Need to spawn a room with a BOTTOM door
            // Need to spawn a room with a RIGHT door
        }
    }
}
