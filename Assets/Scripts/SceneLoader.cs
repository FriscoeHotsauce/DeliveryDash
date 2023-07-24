using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }

    public void loadMainScene(){
        SceneManager.LoadScene(1);
    }

    public void loadUpgradesScene(){
        SceneManager.LoadScene(2);
    }

    public void exitGame(){
        Application.Quit();
    }
}
