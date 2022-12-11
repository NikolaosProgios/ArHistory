using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScript : MonoBehaviour{
    
    private void LoadMenuScene() => SceneManager.LoadScene("MenuScene");

    private void ExitGame() => Application.Quit();

    public GameObject GuidePanel;    
    private void ShowMoreInfo(){       
        if (GuidePanel != null){
            bool isActive = GuidePanel.activeSelf;
            GuidePanel.SetActive(!isActive);            
        }       
    }
}