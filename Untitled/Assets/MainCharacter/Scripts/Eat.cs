using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{
    public float health = 100;

    public GameEVManager game;

    public Image uiHealth;

    void Update()
    {
        if(game.activateStart == true)
        {
            health -= 2 * Time.deltaTime;
            uiHealth.fillAmount = health/100;
        }
    }

    void OnTriggerEnter(Collider other)
    { 
        if(other.tag == "food")
        {
            Destroy(other.gameObject);
            health += 10;
        }
    }
}
