using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public float speed = 1f;
    private Transform objective;

    private bool chasing = false;

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


        Vector3 MoveDirection = new Vector3(Random.Range(-20, 20) * speed, Random.Range(-20, 20) * speed, 0);

        transform.LookAt(MoveDirection);

        rb.AddForce(MoveDirection);

        canMove = true;
    }

    void ChasePlayer()
    {
        this.transform.LookAt(objective);
        Vector3 direction = objective.position - this.transform.position;
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            objective = other.transform;
            chasing = true;
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
