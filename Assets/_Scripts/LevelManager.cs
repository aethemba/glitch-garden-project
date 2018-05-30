using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    void Start(){
        if (autoLoadNextLevelAfter <= 0) {
            Debug.Log("Disabled Autoload");
        } else {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);        
        }

    }

    public void LoadLevel(string name){
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Application.Quit ();
	}

    public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
