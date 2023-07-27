using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private Transform cameraTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        cameraTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        virtualCamera.Follow = cameraTarget.transform;
    }
}
