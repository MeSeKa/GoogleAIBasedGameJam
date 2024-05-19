using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform lookAt;

    Transform desiredPosition;
    float desiredSize = 20f;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float zoomSpeed = 3f;

    [SerializeField] Transform startPosition;
    [SerializeField] Transform playerPosition;
    [SerializeField] Camera _camera;

    [SerializeField] float startDistance=20;
    [SerializeField] float playerDistance=5;

    private void Awake()
    {
        desiredPosition = startPosition;
        desiredSize = startDistance;
        if(_camera == null)
        {
            _camera = Camera.main;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            desiredPosition = startPosition;
            desiredSize = startDistance;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            desiredPosition = playerPosition;
            desiredSize = playerDistance;
        }
    }

    private void LateUpdate()
    {
        if (desiredPosition != null && (desiredPosition.position - transform.position).magnitude >= .15)
        {
            transform.position += (desiredPosition.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        }

        if(_camera.orthographicSize != desiredSize)
        {
            _camera.orthographicSize += (desiredSize - _camera.orthographicSize) * zoomSpeed * Time.deltaTime;
        }
    }
}
