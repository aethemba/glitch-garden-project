using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
    SpriteRenderer spriteRenderer;
    Color originalColor;

    public GameObject defenderPrefab;   
    public static GameObject selectedDefender;

    private Button[] buttonArray;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        originalColor = spriteRenderer.color;

        spriteRenderer.color = Color.black;
        buttonArray = FindObjectsOfType<Button>();
    }


    private void OnMouseDown()
    {

        foreach (Button button in buttonArray) {
            button.GetComponent<SpriteRenderer>().color = Color.black;
        }


        if (selectedDefender) {
            selectedDefender = null;
        } else {
            selectedDefender = defenderPrefab;
            spriteRenderer.color = originalColor;
        }
        
    }

}
