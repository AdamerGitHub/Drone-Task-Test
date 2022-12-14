using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    [SerializeField] ChangeCamera changeCamera;
    [SerializeField] GameObject drone;

    bool isSpawned;

    void Start()
    {
        //drone.SetActive(false);
    }

    void Update()
    {
        if (!isSpawned)
        {
            SpawnAtMousePosition();
        }
    }

    void SpawnAtMousePosition()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            Ray ray = changeCamera.currentCamera.ScreenPointToRay(Input.mousePosition);

            if(Input.touchCount > 0)
            {
                ray = changeCamera.currentCamera.ScreenPointToRay(Input.touches[0].position);
            }

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, 3))
            {
                drone.SetActive(true);
                drone.transform.position = hit.point + Vector3.up * 5;

                changeCamera.mapCamera.Priority = 0;
                changeCamera.droneCamera.Priority = 10;
            }
            isSpawned = true;
        }
    }
}
