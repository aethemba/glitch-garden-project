using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVolume : MonoBehaviour {

	
	void Start () {
        float volume = PlayerprefsManager.GetMasterVolume();
        MusicManager musicManager = FindObjectOfType<MusicManager>();
        if (musicManager != null) {
            musicManager.SetVolume(volume);

        }
	}

}
