using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {

    private Attacker attacker;
    private Animator animator;

    void Start()
    {
        attacker = GetComponent<Attacker>();  
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (!obj.GetComponent<Defender>()) {
            return;
        }

        Debug.Log("Setting isAttacking to true");
        animator.SetBool("isAttacking", true);
        Debug.Log(animator.GetBool("isAttacking"));
        attacker.Attack(obj);


    }
}
