using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject bulletPrefab;
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

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0f;

            Transform childTransform = this.transform.GetChild(0);
            Vector3 childPosition = childTransform.position;
            GameObject bullet = Instantiate(bulletPrefab, childPosition, Quaternion.AngleAxis(angle-=angleOffset, Vector3.forward));

        }
    }
}