using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed = 1f;

    public GameEVManager game;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (game.activateStart == true)
        {
            if (Input.GetMouseButton(0))
            {



                Vector3 WorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                WorldPos.z = 0;

                Vector3 moveDirection = WorldPos - transform.position;

                transform.LookAt(WorldPos);

                transform.position += moveDirection * speed * Time.deltaTime;
                
            }
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 WorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                WorldPos.z = 0;
                if (touch.phase == TouchPhase.Began)
                {
                    Vector3 moveDirection = WorldPos - transform.position;

                    transform.LookAt(WorldPos);

                    transform.position += moveDirection * speed * Time.deltaTime;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    Vector3 moveDirection = WorldPos - transform.position;

                    transform.LookAt(WorldPos);

                    transform.position += moveDirection * speed * Time.deltaTime;
                }
                else if (touch.phase == TouchPhase.Stationary)
                {
                    Vector3 moveDirection = WorldPos - transform.position;

                    transform.LookAt(WorldPos);

                    transform.position += moveDirection * speed * Time.deltaTime;
                }

            }
        }
    }
}
