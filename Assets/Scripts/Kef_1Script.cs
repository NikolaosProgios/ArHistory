using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Kef_1Script : MonoBehaviour
{
    private TextMeshPro textMesH;
    string Q1 = "Ερώτηση 1η";

    void Start()    {
        textMesH = GetComponent<TextMeshPro>();
        textMesH.text = Q1.ToString();
    }

    void Update()    {        
    }

    public void Piso(){
        SceneManager.LoadScene("MenuScene");
    }
}