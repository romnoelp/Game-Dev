using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] topRoom;
    public GameObject[] bottomRoom;
    public GameObject[] leftRoom;
    public GameObject[] rightRoom;
    public GameObject[] endLevelLoot;
    public GameObject closedRoom;
    public GameObject exitRoom;
    public GameObject healRoom;
    public GameObject boss;
    public float waitTime = 2f;
    public int levelNumber = 5;
    private bool bossHasSpawned;
    private bool lootHasSpawned;
    private bool endLevelSpawned;
    public List<GameObject> rooms; 

    void Update()
    {
        if (waitTime > 0 || bossHasSpawned || lootHasSpawned || endLevelSpawned) 
        {
            waitTime -= Time.deltaTime;
            return;
        }

        bossHasSpawned = false;
        lootHasSpawned = false;
        endLevelSpawned = false;

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
            rooms.Remove(roomToReplace);
            Destroy(roomToReplace);
            Instantiate(healRoom, roomToReplace.transform.position, Quaternion.identity);
        }

        // Spawn exit rooms
        List<GameObject> bottomRooms = new List<GameObject>();
        foreach (GameObject room in rooms)
        {
            if (room.name.Contains("Bottom(Clone)"))
            {
                bottomRooms.Add(room);
            }
        }

        if (bottomRooms.Count > 0)
        {
            int randomIndex = Random.Range(0, bottomRooms.Count);
            GameObject roomToReplace = bottomRooms[randomIndex];
            rooms.Remove(roomToReplace);
            Destroy(roomToReplace);
            Instantiate(exitRoom, roomToReplace.transform.position, Quaternion.identity);
        }

        int lastRoomIndex = rooms.Count - 1;
        for (int i = lastRoomIndex; i >= 0; i--)
        {
            string roomName = rooms[i].name;
            if (!roomName.Contains("Heal") && !roomName.Contains("Closed") && !roomName.Contains("Entry"))
            {
                if (levelNumber % 5 != 0)
                {
                    int random = Random.Range(0, endLevelLoot.Length);
                    Instantiate(endLevelLoot[random], rooms[i].transform.position, Quaternion.identity);
                    endLevelSpawned = true;
                }
                else
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    endLevelSpawned = true;
                }
                break;
            }
            else
            {
                lastRoomIndex = i - 1;
            }
        }
    }
}
