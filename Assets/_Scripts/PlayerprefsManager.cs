using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerprefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_UNLOCKS = "level_unlocked_";


    public static void SetMasterVolume(float volume) {
        if (volume > 0f && volume < 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(float difficulty) {
        if (difficulty >= 1f && difficulty <= 3f) {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
    }

    public static float GetDifficulty() {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void UnlockLevel(int level) {
        if (level <= SceneManager.sceneCount -1 ) {
            PlayerPrefs.SetInt(LEVEL_UNLOCKS + level.ToString(), 1);
        }
    } 

    public static bool IsLevelUnlocked(int level){
        int key = PlayerPrefs.GetInt(LEVEL_UNLOCKS + level.ToString());

        if (level <= SceneManager.sceneCount -1 ) {
            if (key == 1) {
                return true;
            }
        }

        return false;
    }

}
