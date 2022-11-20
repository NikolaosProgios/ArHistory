using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Kef_1Script : MonoBehaviour
{
    public TMP_Text TableQuestion;
    public TMP_Text Answer1Text;
    public TMP_Text Answer2Text;
    public TMP_Text Answer3Text;
    int score;
    int i, k, j;

    string[] Questions = {
        "����� ���������� ����������� ������� ���� ����������� "+
            "��� ��� ������� ����������;",
        "���� ���������� �� ������������� ��������� ���������� �� ���� "+
                "�� ������� ��� ��� �����; �� ���������� ������;" +
        "���� �� ������"
    };
    string[,] Answers = { { "1Anse1 ", "1Anse2 ", "1Anse3" },
                          { "2Anse1 ", "2Anse2 ", "3Anse3" },
                          { "3Anse1 ", "3Anse2 ", "3Anse3" }
    };

    void Start()
    {
        i = 0; k = 0; j = 0;
        TableQuestion.text = Questions[i++].ToString();
        Answer1Text.text = Answers[k, j++].ToString();
        Answer2Text.text = Answers[k, j++].ToString();
        Answer3Text.text = Answers[k++, j++].ToString();
        j = 0;
    }
    private bool LoadNextQ()
    {
        bool endKef = false;
        if ((i < Questions.Length) & (k < Answers.Length))
        {
            TableQuestion.text = Questions[i++].ToString();
            Answer1Text.text = Answers[k, j++].ToString();
            Answer2Text.text = Answers[k, j++].ToString();
            Answer3Text.text = Answers[k++, j++].ToString(); j = 0;
        }
        else
        {
            endKef = true;
        }
        return endKef;
    }
    void Update() { }


    public void Piso()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
