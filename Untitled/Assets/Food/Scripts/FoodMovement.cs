using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    public float speed = 5;

    private bool canMove = true;
    private Rigidbody rb;


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (canMove == true)
        {
            Invoke("move", Random.Range(1, 5));
            canMove = false;
        }

    }

    void move()
    {


        Vector3 MoveDirection = new Vector3(Random.Range(-20, 20) * speed, Random.Range(-20, 20) * speed, 0);

        transform.LookAt(MoveDirection);

        rb.AddForce(MoveDirection);

        canMove = true;
    }

}
