using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed = 5f;

    public GameEVManager game;

    void Update()
    {
        if (game.activateStart == true)
        {
            if (Input.GetMouseButton(0))
            {



                Vector3 WorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                WorldPos.z = 0f;

                Vector3 moveDirection = WorldPos - transform.position;

                transform.LookAt(WorldPos);

                transform.position += moveDirection * speed * Time.deltaTime;
            }
        }
    }
}
