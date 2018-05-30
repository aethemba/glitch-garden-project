using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stone : MonoBehaviour {

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }


    void OnTriggerStay2D(Collider2D collision)
    {
        
        GameObject obj = collision.gameObject;

        if (!obj.GetComponent<Attacker>()) {
            return;
        } 
        animator.SetTrigger("UnderAttack Trigger");

    }
}
