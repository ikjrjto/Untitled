using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : MonoBehaviour
{
    public float damage;
    public Animator animator;


    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Eat>().GetDamage(damage);
            animator.SetTrigger("Bite");
        }
        
    }
}
