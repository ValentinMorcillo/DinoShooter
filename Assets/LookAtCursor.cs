using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    private Camera mainCamera;
    public float angleOffset = 0f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 cursorPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cursorDirection = cursorPosition - transform.position;
        float angle = Mathf.Atan2(cursorDirection.y, cursorDirection.x) * Mathf.Rad2Deg;
        angle += angleOffset; // Apply the angle offset
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}