using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Transform target;
    Camera camera;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        camera = Camera.main;
    }
    private void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 11, Time.deltaTime * 2f);
        }
        else
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 7, Time.deltaTime * 2f);
        }

        Vector3 vector3 = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 2f);
        transform.position = new Vector3(vector3.x, vector3.y,-12);
    }
}
