using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    private StarDisplay starDisplay;
    public int starCost = 100;

    void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();

    }

    public void AddStars(int amount) {
        starDisplay.AddStars(amount);    
    }
}
