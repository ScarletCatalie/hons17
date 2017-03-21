using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SceneTimer : MonoBehaviour {

    private float timer = 10f;
    public int sceneNumber;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);
        }

    }
}
