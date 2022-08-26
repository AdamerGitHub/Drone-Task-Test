using UnityEngine;
using Cinemachine;

public class ChangeCamera : MonoBehaviour
{
    public CinemachineVirtualCamera mapCamera;
    public CinemachineVirtualCamera droneCamera;
    public Camera currentCamera;

    void Start()
    {
        //currentCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
}
