using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject PlayButton;


	public void OnStartGame () {
        SceneManager.LoadScene("Int_Station");
	}
	

}
