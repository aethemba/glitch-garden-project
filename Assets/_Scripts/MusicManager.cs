using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;
	
	void Awake () {
        DontDestroyOnLoad(gameObject);
    }

    void Start(){
	}


    public void SetVolume(float volume) {
        audioSource.volume = volume;
    }

    void OnEnable(){
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable(){
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){

        AudioClip clip = levelMusicChangeArray[scene.buildIndex];
        if (clip != null) {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = levelMusicChangeArray[scene.buildIndex];
            audioSource.loop = true;
            audioSource.Play();            
        }

    }

}
