using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour{

    public void OpenKefN(int n){
        SceneManager.LoadScene("Kef_"+n);
    }
    public void Piso()    {
        SceneManager.LoadScene("WelcomeScene");
    }
}