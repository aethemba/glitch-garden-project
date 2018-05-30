using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 5f;
    public float damage = 10f;

	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Attacker>()){
            GameObject attacker = collision.gameObject;

            Health health = attacker.GetComponent<Health>();
            health.DoDamage(damage);

            Destroy(gameObject);
        }
    }
}
