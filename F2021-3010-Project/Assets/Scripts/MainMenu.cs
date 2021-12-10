using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Load game scene
    public void StartGame (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NavMenu (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //Quit game
    public void ExitGame (){
        //quit does not work in unity editor so use debug to check
        Debug.Log("Quitting Game.");
        Application.Quit();
    }
}
