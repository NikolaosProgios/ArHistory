using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Kef_2Script : MonoBehaviour
{
    public GameObject Welcome_Panel;
    public TMP_Text TableQuestion;
    public GameObject LetsStart, AnswersCanvas;
    public Button Answer1btn, Answer2btn, Answer3btn; 
    int correctAnsw = 0;
    int line = 0, row = 0;

    string[] Questions = {
        "Για ποιους λόγους οι Σουλιώτες ήταν γνωστοί ως ικανότατοι πολεμιστές;",
        "Ποιο ήταν το υπέρτατο αγαθό για τους Σουλιώτες με βάση τα κείμενα των πηγών;",
        "Ετσι με αρέσει"
    };
    
    int[] correctAnswers = { 1, 2, 2 };

    public TMP_Text TitlePanel;
    public GameObject WelcomeImage; public GameObject FinishedImage;
    public GameObject StarKef2Game; public GameObject EndKef2NextGame;

    void Start()
    {
        ShowHideWelcomePanel();
        TitlePanel.text = "Καλωσήρθες στην 2η Ενότητα του παιχνιδού μας";
        WelcomeImage.SetActive(true);
        FinishedImage.SetActive(false);
        StarKef2Game.SetActive(true);
        EndKef2NextGame.SetActive(false);
    }
    public void Startof()
    {
        ShowHideWelcomePanel();
        LoadQnA();
    }

    public void PressedAnswer(int choice)
    {
        if (choice == correctAnswers[--line]) { correctAnsw++; } line++;
        
        if (LoadQnA()) {
            TableQuestion.text = "Τέλος 2ης Ενότητας."
                + "\nΣωστες Απαντήσεις:" + correctAnsw
                + "\nΛανθασμένες Απαντήσεις:" + (Questions.Length - correctAnsw);
            AnswersCanvas.SetActive(false);
            
            //Invoke for Delay
            ShowHideWelcomePanel();
            TitlePanel.text = "Ολοκλήρωσες 2η Ενότητα του παιχνιδού μας";
            WelcomeImage.SetActive(false);
            FinishedImage.SetActive(true);
            StarKef2Game.SetActive(false);
            EndKef2NextGame.SetActive(true);
        }
    }

    public void Piso() { SceneManager.LoadScene("MenuScene"); }

    public void OpenKefN(int n)
    {
        SceneManager.LoadScene("Kef_" + n);
    }

    private void ShowHideWelcomePanel()
    {
        if (Welcome_Panel != null)
        {
            bool isActive = Welcome_Panel.activeSelf;
            Welcome_Panel.SetActive(!isActive);
        }
    }

    
    public Sprite[] imagesQ1 = new Sprite[3];
    public Sprite[] imagesQ2 = new Sprite[3];
    public Sprite[] imagesQ3 = new Sprite[3];

    private bool LoadQnA()
    {
        bool endKef = false;
        if ((line < Questions.Length))
        {
            TableQuestion.text = Questions[line++].ToString();
            Answer1btn.image.sprite = imagesQ1[row];
            Answer2btn.image.sprite = imagesQ2[row];
            Answer3btn.image.sprite = imagesQ3[row]; row++;
        }
        else
        {
            endKef = true;
        }
        return endKef;
    }


}
