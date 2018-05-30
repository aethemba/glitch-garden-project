using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour {

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Lose reached");
        if (collision.gameObject.GetComponent<Attacker>()) {
            levelManager.LoadLevel("03b Lose");
        }
    }
}
