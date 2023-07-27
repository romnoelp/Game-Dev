using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] topRoom;
    public GameObject[] bottomRoom;
    public GameObject[] leftRoom;
    public GameObject[] rightRoom;
    public GameObject closedRoom;
    public GameObject exitRoom;
    public GameObject healRoom;
    public GameObject[] endLevelLoot;
    public GameObject boss;
    public float waitTime = 2f;
    public int levelNumber = 5;
    private bool bossHasSpawned;
    private bool lootHasSpawned;
    private bool hasHealRoom; // Flag for Heal room
    private bool hasExitRoom; // Flag for Exit room
    public List<GameObject> rooms; 

    void Update()
    {
        if (waitTime > 0 || bossHasSpawned || lootHasSpawned) 
        {
            waitTime -= Time.deltaTime;
            return;
        }

        // Reset the flags before entering the loop
        hasHealRoom = false;
        hasExitRoom = false;

        // Check for Heal or Exit rooms and set the flags
        for (int i = 0; i < rooms.Count; i++)
        {
            string roomName = rooms[i].name;
            if (roomName.Contains("Heal"))
            {
                hasHealRoom = true; // Set the flag if there is a heal room
            }
            else if (roomName.Contains("Exit"))
            {
                hasExitRoom = true; // Set the flag if there is an exit room
            }
        }

        // Reset the boss and loot flags before entering the spawning loop
        bossHasSpawned = false;
        lootHasSpawned = false;

        // Proceed with spawning boss or loot
        for (int i = 0; i < rooms.Count - 1; i++)
        {
            string roomName = rooms[i].name;
            if (roomName.Contains("Closed") || roomName.Contains("Entry") || roomName.Contains("Heal") || roomName.Contains("Exit"))
            {
                // Skip the current room if it has the specified names
                continue;
            }

            if (levelNumber % 5 != 0)
            {
                int random = Random.Range(0, endLevelLoot.Length);
                Instantiate(endLevelLoot[random], rooms[i].transform.position, Quaternion.identity);
                lootHasSpawned = true;
            }
            else
            {
                Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                bossHasSpawned = true;
            }

            // Spawn only once, then exit the loop
            break;
        }

        // Debug.log if there is a heal or exit room between the rooms
        if (hasHealRoom)
        {
            Debug.Log("There is a Heal room between the rooms!");
        }

        if (hasExitRoom)
        {
            Debug.Log("There is an Exit room between the rooms!");
        }

        // Select a room named "Top" randomly, delete it, and replace it with healRoom
        List<GameObject> topRooms = new List<GameObject>();
        foreach (GameObject room in rooms)
        {
            if (room.name.Contains("Top(Clone)"))
            {
                topRooms.Add(room);
            }
        }

        if (topRooms.Count > 0)
        {
            int randomIndex = Random.Range(0, topRooms.Count);
            GameObject roomToReplace = topRooms[randomIndex];

            // Destroy the selected room
            rooms.Remove(roomToReplace);
            Destroy(roomToReplace);

            // Instantiate the healRoom to replace the destroyed room
            Instantiate(healRoom, roomToReplace.transform.position, Quaternion.identity);
        }
    }
}
