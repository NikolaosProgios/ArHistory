using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Kef_1Script : MonoBehaviour
{
    public GameObject Kef_Welcome_Panel;
    public TMP_Text TableQuestion;
    public GameObject LetsStart;
    public GameObject Answer1btn; public TMP_Text Answer1Text;
    public GameObject Answer2btn; public TMP_Text Answer2Text;
    public GameObject Answer3btn; public TMP_Text Answer3Text; 
    int correctAnsw=0;
    int line=0, row=0, column=0;

    string[] Questions = {
        "Ποιες ομοιότητες παρατηρείτε ανάμεσα στην Αμερικανική "+
            "και την Γαλλική Επανάσταση;",
        "Ποια θεωρούνται τα σημαντικότερα ανθρώπινα δικαιώματα με βάση "+
                "τα κείμενα των δύο πηγών; Τι πιστεύουμε σήμερα;" ,
        "Ετσι με αρέσει"
    };
    string[,] Choices = { { "1Anse1 ", "1Anse2 ", "1Anse3" },
                          { "2Anse1 ", "2Anse2 ", "2Anse3" },
                          { "3Anse1 ", "3Anse2 ", "3Anse3" }
    };

    int[] correctAnswers = {1,2,2};
    
    public TMP_Text TitlePanel;    
    public GameObject WelcomeImage;    public GameObject FinishedImage;
    public GameObject StarKef1Game;    public GameObject EndKef1NextGame;
    void Start()
    {
        ShowHideWelcomePanel();       
        TitlePanel.text = "Καλωσήρθες στην 1η Ενότητα του παιχνιδού μας";
        WelcomeImage.SetActive(true);
        FinishedImage.SetActive(false);
        StarKef1Game.SetActive(true);
        EndKef1NextGame.SetActive(false);
    }
    public void Startof()
    {
        ShowHideWelcomePanel();
        LoadQnA();
    }
        

    public void PressedAnswer(int choice)
    {
        if (choice == correctAnswers[--line]) {
            correctAnsw++; line++;
        }
        if (LoadQnA())
        {
            TableQuestion.text = "Τέλος 1ης Ενότητας."
                + "\nΣωστες Απαντήσεις:" + correctAnsw
                + "\nΛανθασμένες Απαντήσεις:" + (Questions.Length-correctAnsw);
            Answer1btn.SetActive(false);
            Answer2btn.SetActive(false);
            Answer3btn.SetActive(false);
            //Invoke for Delay
            ShowHideWelcomePanel();
            TitlePanel.text = "Ολοκλήρωσες 1η Ενότητα του παιχνιδού μας";
            WelcomeImage.SetActive(false);
            FinishedImage.SetActive(true);
            StarKef1Game.SetActive(false);
            EndKef1NextGame.SetActive(true);
        }

    }


    public void Piso() {
        SceneManager.LoadScene("MenuScene");
    }
    
    public void OpenKefN(int n)
    {
        SceneManager.LoadScene("Kef_" + n);
    }

    private void ShowHideWelcomePanel()
    {
        if (Kef_Welcome_Panel != null)
        {
            bool isActive = Kef_Welcome_Panel.activeSelf;
            Kef_Welcome_Panel.SetActive(!isActive);
        }
    }

    private bool LoadQnA()
    {
        bool endKef = false;
        if ((line < Questions.Length) & (row < Choices.Length))
        {
            TableQuestion.text = Questions[line++].ToString();
            Answer1Text.text = Choices[row, column++].ToString();
            Answer2Text.text = Choices[row, column++].ToString();
            Answer3Text.text = Choices[row++, column].ToString(); column = 0;
        }
        else
        {
            endKef = true;
        }
        return endKef;
    }
}
