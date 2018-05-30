using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderSpawner : MonoBehaviour {

    public Camera camera;
    private GameObject defenders;
    private StarDisplay starDisplay;

    void Start()
    {
        camera = FindObjectOfType<Camera>();
        defenders = GameObject.Find("Defenders");
        starDisplay = FindObjectOfType<StarDisplay>();

        if (starDisplay == null) {
            Debug.Log("Star display not found");
        }

        if (defenders == null) {
            defenders = new GameObject( "Defenders");
        }
    }

    void SpawnDefender(Vector3 newPos, GameObject defenderPrefab) {
        Vector3 pos = new Vector3(newPos.x, newPos.y, 0f);
        GameObject newDefender = Instantiate(defenderPrefab, pos, Quaternion.identity);
        newDefender.transform.parent = defenders.transform;   
    }

    void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 newPos = SnapToGrid(rawPos);

        GameObject defenderPrefab = Button.selectedDefender;

        if (defenderPrefab) {
            int cost = defenderPrefab.GetComponent<Defender>().starCost;

            if (starDisplay.UseStars(cost) == StarDisplay.Status.SUCCESS) {
                
                SpawnDefender(newPos, defenderPrefab);

            } else {
                Debug.Log("not enough stars");
            }

        }

    }

    Vector2 SnapToGrid(Vector2 rawPos) {
        float newX = Mathf.RoundToInt(rawPos.x);
        float newY = Mathf.RoundToInt(rawPos.y);
        return new Vector2(newX, newY);
    }


    Vector2 CalculateWorldPointOfMouseClick() {
        float xPos = Input.mousePosition.x;
        float yPos = Input.mousePosition.y;

        Vector3 pos = new Vector3(xPos, yPos, 10f);
        Vector3 newPos = camera.ScreenToWorldPoint(pos);
        return new Vector2(newPos.x, newPos.y);
    }

}
