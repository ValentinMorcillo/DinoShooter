using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    private Transform _transform;
  

    void Start()
{
    _transform = transform;
}

void Update()
{
    // Move the object forward in the direction it is facing
    _transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy"))
        {
            Destroy(gameObject);
            Debug.Log("pew");
            
        }
    }
}
