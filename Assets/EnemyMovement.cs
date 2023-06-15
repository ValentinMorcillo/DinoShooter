using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public string weakness = "Bullet";
    public string follow = "Player";
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(follow).transform;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(weakness))
        {
            Destroy(gameObject);
        }
    }
}
