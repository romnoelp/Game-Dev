using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    private Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Player Spawn Point").GetComponent<Transform>();
        Instantiate(player, spawnPoint.position, spawnPoint.rotation);
    }
}
