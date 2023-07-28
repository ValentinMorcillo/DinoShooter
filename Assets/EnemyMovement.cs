using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public float minSpeed = 4.0f;
    public float maxSpeed = 10.0f;
    public string weakness = "Bullet";
    public string follow = "Player";
    private Transform target;
    private GameObject player;
    private float speed = 5.0f;
    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame

    void Update()
    {
        Swarm();
       
    }


    private void Swarm()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(weakness))
        {
            Destroy(gameObject);
            
        }
    }

    
}
