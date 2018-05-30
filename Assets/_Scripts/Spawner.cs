using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabs;
    private GameObject attackers;

    void Start()
    {
        attackers = GameObject.Find("Attackers");

        if (attackers == null) {
            attackers = new GameObject("Attackers");
        }
    }

    bool IsTimeToSpawn(GameObject obj) {
        Attacker attacker = obj.GetComponent<Attacker>();

        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;  // if meanspawndelay = 0.5 --> 1/0.5 = 2 ## if meanspawndelay = 2 --> 1/2 = 0.5


        if (Time.deltaTime > meanSpawnDelay) {
            Debug.Log("Spawn framerate capped by framerate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime;  // Example, 1/5 = 0.2 * time.delta (.1) = 0.02

        // Gives random float value between 0 and 1
        return Random.value < (threshold / 5);  // 5 lanes
    }

    void Update()
    {
        foreach (GameObject attacker in attackerPrefabs) {
            if (IsTimeToSpawn(attacker)) {
                Spawn(attacker);
            }
        }
    }

    void Spawn(GameObject myGameObject) {
        GameObject attacker = Instantiate(myGameObject, transform.position, Quaternion.identity);
        attacker.transform.parent = transform;
        attacker.transform.position = transform.position;
    }

}
