using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject food;

    public Vector3 startPos, endPos;

    private GameObject SetFood;
    private bool token;

    void Start()
    {
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
        CreateFood();
    }

    void Update()
    {
        if(token == false)
        {
            Invoke("CreateFood", Random.Range(2, 8));
            token = true;
        }
    }

    void CreateFood()
    {
        SetFood = Instantiate(food);
        SetFood.transform.position = new Vector3(Random.Range(startPos.x, endPos.x), Random.Range(startPos.y, endPos.y), 0);
        token = false;
    }
}
