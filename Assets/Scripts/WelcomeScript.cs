using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScript : MonoBehaviour{
    public void ExitGame()    {
        Application.Quit();
        Debug.Log("QUIT");
    }
    public void LoadMenuScene()    {
        SceneManager.LoadScene("MenuScene");
        Debug.Log("MenuScene");
    }    
    public GameObject Panel;    
    public void ShowMoreInfo()    {       
        if (Panel != null)        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);            
        }       
    }
}




