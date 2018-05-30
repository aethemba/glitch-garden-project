using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    private Animator animator;
    private GameObject projectileParent;
    private Spawner spawner;

    void Start()
    {
        animator = GetComponent<Animator>(); 
        projectileParent = GameObject.Find("Projectiles");

        if (projectileParent == null) {
            projectileParent = new GameObject("Projectiles");
        }

        SetSpawner();
    }

    void SetSpawner(){
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach(Spawner spawnerItem in spawners) {
            if (Mathf.Approximately(spawnerItem.transform.position.y, transform.position.y)) {
                spawner = spawnerItem;
            }
        }
        if (spawner == null) {
            Debug.Log("No Spawner found");
        }

    }

    bool IsAttackerAhead() {
        Attacker[] attackers = FindObjectsOfType<Attacker>();

        foreach(Attacker attacker in attackers) {
            if (Mathf.Approximately(attacker.transform.position.y, transform.position.y)) {
                if (attacker.transform.position.x > transform.position.x) {
                    return true;
                }
            }
        }
        return false;

    }

    void Update()
    {
        if (IsAttackerAhead()) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }

    }

    void Fire() {
        GameObject newProj = Instantiate(projectile);
        newProj.transform.parent = projectileParent.transform;
        newProj.transform.position = transform.Find("Gun").position;
    }


}
