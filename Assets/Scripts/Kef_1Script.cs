using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Kef_1Script : MonoBehaviour
{
    private TextMeshPro textMesH;
    string[] Que1 = {
        "����� ���������� ����������� ������� ���� ����������� "
            +"��� ��� ������� ����������;",
        "���� ���������� �� ������������� ��������� ���������� �� ���� "
                +"�� ������� ��� ��� �����; �� ���������� ������;"
    };

    void Start(){
        textMesH = GetComponent<TextMeshPro>();
        textMesH.text = Que1[0].ToString();
        Debug.Log(" " + Que1[0]);
        
    }

    void Update(){        
    }

    public void Piso(){
        SceneManager.LoadScene("MenuScene");
    }
}