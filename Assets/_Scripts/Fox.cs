using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

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

        if (obj.GetComponent<Stone>()) {
            animator.SetTrigger("Jump Trigger");
        } else {
            animator.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
    }
}
