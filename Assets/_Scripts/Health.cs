using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    
    public float health = 100f;

    void Die() {
        Destroy(gameObject);
    }

    public void DoDamage(float damage) {
        health -= damage;

        if (health < 0) {
            Die();
        } 
    }
}
