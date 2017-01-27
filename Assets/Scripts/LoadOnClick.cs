using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

       public void LoadScene(int level)
    {
        SceneManager.LoadScene("Intro_Station");
    }


}
