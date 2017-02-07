using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelTrigger : MonoBehaviour {

    public int sceneNumber; 

	// Use this for initialization
	void OnTriggerEnter (Collider Other)
    {
        SceneManager.LoadScene(sceneNumber);
	}
	
}
