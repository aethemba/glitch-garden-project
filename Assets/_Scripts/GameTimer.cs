using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {


    public int levelSeconds = 60;

    private bool started = true;
    private Slider slider;

    private float remaining;
    private float elapsed = 0f;
    private AudioSource audioSource;
    private LevelManager levelManager;
    private GameObject win;
    private Text winText;
    //private Color originalColor;

	void Start () {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();

        win = GameObject.Find("Win");
        if (!win) {
            Debug.Log("Win object not found");
        }
        win.SetActive(false);
        //originalColor = winText.color;
        //winText = win.GetComponent<Text>();
        //winText.color = Color.clear;

        slider.value = 0f;

	}

    void NextLevel(){
        levelManager.LoadNextLevel();
    }

    void Win(){
        win.SetActive(true);
        //winText.color = originalColor;

        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
        Invoke("NextLevel", audioSource.clip.length);
    }

    
    void Update () {
        
        if (started) {
            
            elapsed += Time.deltaTime; // Time.timeSinceLevelLoaded

            remaining = elapsed / levelSeconds;

            slider.value = remaining;

            if (remaining >= 1f) {
                Win();
            }
        }

	}
}
