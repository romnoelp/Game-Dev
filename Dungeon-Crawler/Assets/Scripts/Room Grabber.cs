using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGrabber : MonoBehaviour
{
    private RoomTemplate roomTemplate;

    // Start is called before the first frame update
    void Start()
    {
        roomTemplate = GameObject.FindGameObjectWithTag("Room Template").GetComponent<RoomTemplate>(); 
        roomTemplate.rooms.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
