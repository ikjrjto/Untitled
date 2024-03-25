using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Diveing : MonoBehaviour
{
    public float speed = 1f;
    private Transform objective;

    private bool chasing = false;
    private bool ready = false;
    private bool canMove = true;
    private Rigidbody rb;


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (chasing == false && canMove == true)
        {
            Invoke("move", Random.Range(1, 5));
            canMove = false;
        }
        else if (chasing == true)
        {
            ChasePlayer();
        }

    }

    void move()
    {


        Vector3 MoveDirection = new Vector3(Random.Range(-50, 50) * speed, Random.Range(-50, 50) * speed, 0);

        transform.LookAt(MoveDirection);

        rb.AddForce(MoveDirection);

        canMove = true;
    }

    void ChasePlayer()
    {
        if (ready == false)
        {
            this.transform.LookAt(objective);
        }
        
        if (canMove == true)
        {
            Invoke("Dive", 5);
            canMove = false;
        }
    }

    void Dive()
    {
        Vector3 MoveDirection = objective.position - this.transform.position;
        rb.AddForce(MoveDirection * speed * 50);
        ready = true;
        Invoke("Ready", 6);
    }

    void Ready()
    {
        ready = false;
        canMove = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            objective = other.transform;
            chasing = true;
            canMove = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            objective = other.transform;
            chasing = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            chasing = false;
        }
    }
}
