using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attacker : MonoBehaviour {

    [Range(-1f, 1.5f)]
    private float currentSpeed;

    [Tooltip("Average number of seconds between appearances")]
    public float seenEverySeconds;
        
    private GameObject currentTarget;
    private Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
    }
    
    void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        //Debug.Log ("Current target of " + this.gameObject + ": " + currentTarget);

        if (currentTarget == null) {

            //Debug.Log("No current target for " + gameObject.name);
            animator.SetBool("isAttacking", false);
        } else {
            //Debug.Log("Current tarrget is: " + currentTarget.name);
            //Debug.Log(animator.GetBool("isAttacking"));
        }

	}

    public void SetCurrentSpeed(float speed) {
        currentSpeed = speed;
    }

    // Called from animator
    public void StrikeCurrentTarget(float damage) {
        Debug.Log("String target");
        if (currentTarget) {
            Health health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DoDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj) {
        Debug.Log(gameObject.name + " Attacking " + obj.name);
        currentTarget = obj;
    }
}
