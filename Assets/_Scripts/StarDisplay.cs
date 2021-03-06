﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {


    private Text starText;
    private int stars = 200;
    public enum Status {SUCCESS, FAILURE};

    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    public void AddStars(int amount) {
        stars += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount) {
        if (stars >= amount) {
            stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;

    }

    void UpdateDisplay() {
        starText.text = stars.ToString();

    }
}
