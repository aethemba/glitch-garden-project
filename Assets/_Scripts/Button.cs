using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {
    SpriteRenderer spriteRenderer;
    Color originalColor;

    public GameObject defenderPrefab;   
    public static GameObject selectedDefender;

    private Text costText;
    private Button[] buttonArray;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        originalColor = spriteRenderer.color;

        spriteRenderer.color = Color.black;
        buttonArray = FindObjectsOfType<Button>();

        costText = GetComponentInChildren<Text>();
        if (!costText) {
            Debug.Log("cost Text for " + name + " not found");
        }
        costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();

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
