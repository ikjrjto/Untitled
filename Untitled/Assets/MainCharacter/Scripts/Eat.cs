using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;

    public GameEVManager game;
    public MenuManager menu;

    public Image uiHealth;

    private MovementPlayer move;
    private Animator animator;

    void Start()
    {
        move = GetComponent<MovementPlayer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        if(health <= 0)
        {
            Death();
        }
        if(game.activateStart == true)
        {
            health -= 1 * Time.deltaTime;
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

    public void GetDamage(float damage)
    {
        health = health - damage;
    }

    void Death()
    {
        move.rb.freezeRotation = false;
        move.rb.AddForce(transform.forward * 5);
        Destroy(move);
        Destroy(animator);
        Invoke("Restart", 3f);
    }
    void Restart()
    {
        menu.OpenMenu("Restart");
    }
}
