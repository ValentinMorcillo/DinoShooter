using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Camera mainCamera;
    public float angleOffset = 0f;
    public int maxMagazine = 5;
    public int magazine = 5;
    public int reloadTime = 1;
    private int reloadCount = 0;
    private SpriteRenderer spriteRenderer;
    public Text balas;
        void Start()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {   
        //Rotate Glock to face cursor
        Vector3 cursorPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cursorDirection = cursorPosition - transform.position;
        float angle = Mathf.Atan2(cursorDirection.y, cursorDirection.x) * Mathf.Rad2Deg;
        angle += angleOffset; // Apply the angle offset
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        balas.text = "Balas: " + magazine;
        //Spawn Bullet when firing
        if (Input.GetMouseButtonDown(0) && magazine > 0)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0f;

            Transform childTransform = this.transform.GetChild(0);
            Vector3 childPosition = childTransform.position;
            GameObject bullet = Instantiate(bulletPrefab, childPosition, Quaternion.AngleAxis(angle-=angleOffset, Vector3.forward));

            magazine -= 1;
        }

        //Reload Magazine
        float zRotation = transform.eulerAngles.z;

        if (zRotation > 160 && zRotation < 290)
        {
            reloadCount += 1;
            if ( reloadCount >= reloadTime)
            {
                reloadCount = 0;
                magazine = maxMagazine;
            }
            
        } 
        else 
        {
            reloadCount = 0;
        } 
    }

}