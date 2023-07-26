using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadTut : MonoBehaviour
{
    public float magazineThreshold = 1f;
    public float opacityDuration = 2f;
    public float fullOpacity = 1f;
    public Renderer objectRenderer; // Reference to the object's renderer component
    public GameObject glock;


    private float currentOpacity = 0f;
    private float timeSinceLowmagazine = 0f;
    private bool isFullOpacity = false;

    void Start()
    {
        // Initialize the object's opacity to 0
        objectRenderer.material.color = new Color(objectRenderer.material.color.r, objectRenderer.material.color.g, objectRenderer.material.color.b, 0f);
    }

    void Update()
    {
        // Assuming the "magazine" variable is accessible from the object's parent
        float magazine = glock.GetComponent<SpawnPrefab>().magazine;

        if (magazine < magazineThreshold)
        {
            timeSinceLowmagazine += Time.deltaTime;
            if (timeSinceLowmagazine >= opacityDuration && !isFullOpacity)
            {
                // Increase opacity to full
                currentOpacity = fullOpacity;
                objectRenderer.material.color = new Color(objectRenderer.material.color.r, objectRenderer.material.color.g, objectRenderer.material.color.b, currentOpacity);
                isFullOpacity = true;
            }
        }
        else
        {
            timeSinceLowmagazine = 0f;
            if (isFullOpacity)
            {
                // Decrease opacity to 0
                currentOpacity = 0f;
                objectRenderer.material.color = new Color(objectRenderer.material.color.r, objectRenderer.material.color.g, objectRenderer.material.color.b, currentOpacity);
                isFullOpacity = false;
            }
        }
    }
}