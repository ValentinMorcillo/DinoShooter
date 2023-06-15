using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsDestroyer : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 objectPosition = transform.position;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(objectPosition);

        if (viewportPosition.x < 0 || viewportPosition.x > 1 ||
            viewportPosition.y < 0 || viewportPosition.y > 1 ||
            viewportPosition.z < 0)
        {
            Destroy(gameObject);
        }
    }
}