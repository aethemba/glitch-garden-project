using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider diffSlider;
    public float volume;
    public float difficulty;
    public LevelManager levelManager;

    private MusicManager musicManager;

	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();

        volume = PlayerprefsManager.GetMasterVolume();
        volumeSlider.value = volume;

        difficulty = PlayerprefsManager.GetDifficulty();
        Debug.Log("Diff: " + difficulty.ToString());
        diffSlider.value = difficulty;    
       
        musicManager.SetVolume(volume);
	    	
	}

    public void SaveAndExit() {
        volume = volumeSlider.value;
        PlayerprefsManager.SetMasterVolume(volume);

        difficulty = diffSlider.value;
        PlayerprefsManager.SetDifficulty(difficulty);
    }

    public void SetDefaults() {
        volume = 0.5f;
        difficulty = 2f;
        volumeSlider.value = volume;
        diffSlider.value = difficulty;
    }
	
	
	void Update () {
        volume = volumeSlider.value;
        musicManager.SetVolume(volume);
	}
}
