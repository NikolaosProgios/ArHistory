using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour{

    private void OpenKefN(int n) => SceneManager.LoadScene("Kef_"+n);

    private void Piso() => SceneManager.LoadScene("WelcomeScene");
}