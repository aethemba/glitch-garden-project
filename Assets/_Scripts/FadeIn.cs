using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeInTime;

    private Image panel;
    private Color currentColor = Color.black;

	void Start () {
        panel = GetComponent<Image>();  
	    
    }

	
	
	void Update () {
        if (Time.timeSinceLevelLoad < fadeInTime) {
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColor.a -= alphaChange;
            panel.color = currentColor;
        } else {
            gameObject.SetActive(false);    
        }
	    
	}
}
