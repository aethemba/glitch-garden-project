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

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameObject obj = collision.gameObject;

        if (!obj.GetComponent<Attacker>()) {
            return;
        } 
        animator.SetBool("isAttacked", true);

    }
}
