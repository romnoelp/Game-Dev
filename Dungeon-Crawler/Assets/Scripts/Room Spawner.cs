using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirectionValue;

    private RoomTemplate roomTemplate;
    private int random;
    private bool roomHasSpawned = false;
    private float pointDestroyerInSecs = 4f;

    private void Start()
    {
        Destroy(gameObject, pointDestroyerInSecs);
        roomTemplate = GameObject.FindGameObjectWithTag("Room Template").GetComponent<RoomTemplate>();
        Invoke("spawnRoom", .2f);
    }

    void spawnRoom()
    {
        if (roomHasSpawned == false) 
        {
            if (openingDirectionValue == 1) {
                random = Random.Range(0, roomTemplate.bottomRoom.Length);
                Instantiate(roomTemplate.bottomRoom[random], transform.position, roomTemplate.bottomRoom[random].transform.rotation);
                
            }
            else if (openingDirectionValue == 2) {
                random = Random.Range(0, roomTemplate.topRoom.Length);
                Instantiate(roomTemplate.topRoom[random], transform.position, roomTemplate.topRoom[random].transform.rotation);
            }
            else if (openingDirectionValue == 3) {
                random = Random.Range(0, roomTemplate.leftRoom.Length);
                Instantiate(roomTemplate.leftRoom[random], transform.position, roomTemplate.leftRoom[random].transform.rotation);
            }
            else if (openingDirectionValue == 4) {
                random = Random.Range(0, roomTemplate.rightRoom.Length);
                Instantiate(roomTemplate.rightRoom[random], transform.position, roomTemplate.rightRoom[random].transform.rotation);
            }
            roomHasSpawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Spawn Point")){
            if (other.GetComponent<RoomSpawner>().roomHasSpawned == false && roomHasSpawned == false) {
                Instantiate(roomTemplate.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            roomHasSpawned = true;
        }
    }
}
