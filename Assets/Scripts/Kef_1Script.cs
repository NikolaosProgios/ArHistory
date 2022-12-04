using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Kef_1Script : MonoBehaviour
{
    public GameObject Welcome_Panel, WelcomeImage, FinishedImage,
            StarKef1Game, EndKef1NextGame;
    public TMP_Text TitlePanel;

    public GameObject AnswersCanvas;
    public TMP_Text TableQuestion,
            Answer1Text, Answer2Text, Answer3Text;
    public Button Answer1, Answer2, Answer3;
    int line, row, column, correctAnsw;

    string[] Questions = {
        "Ποιες ομοιότητες παρατηρείτε ανάμεσα στην Αμερικανική "+
            "και την Γαλλική Επανάσταση;",
        "Ποια θεωρούνται τα σημαντικότερα ανθρώπινα δικαιώματα με βάση "+
                "τα κείμενα των δύο πηγών; Τι πιστεύουμε σήμερα;" ,
        "Ετσι με αρέσει",
        "Photo Answers"
    };
    string[,] Choices = { { "1Anse1 ", "1Anse2 ", "1Anse3" },
                          { "2Anse1 ", "2Anse2 ", "2Anse3" },
                          { "3Anse1 ", "3Anse2 ", "3Anse3" }
    };
    int[] correctAnswers = {1,2,2,1};

    void Start() {        
        ShowHidePanel("Welcome");
    }

    public void Startof() {        
        ShowHidePanel("");
        LoadQnA();
    }       

    public async void PressedAnswer(int choice) {
        if (choice == correctAnswers[--line]) {
            correctAnsw++;           
        } line++;
        if (LoadQnA()) {
            TableQuestion.text = "Τέλος 1ης Ενότητας."
                + "\nΣωστες Απαντήσεις: " + correctAnsw
                + "\nΛανθασμένες Απαντήσεις: " + (Questions.Length-correctAnsw);
            AnswersCanvas.SetActive(false);
            await Task.Delay(3000);
            ShowHidePanel("GoodBye");
        }
    }

    public void Piso() {
        SceneManager.LoadScene("MenuScene");
    }
    
    public void OpenKefN(int n) {
        SceneManager.LoadScene("Kef_" + n);
    }

    private void ShowHidePanel(string ComeOrBye)
    {
        if (ComeOrBye== "Welcome") {
            TitlePanel.text = "Καλωσήρθες στην 1η Ενότητα του παιχνιδού μας";
            WelcomeImage.SetActive(true);
            FinishedImage.SetActive(false);
            StarKef1Game.SetActive(true);
            EndKef1NextGame.SetActive(false);
        }else if (ComeOrBye == "GoodBye") {
            TitlePanel.text = "Ολοκλήρωσες 1η Ενότητα του παιχνιδού μας";
            WelcomeImage.SetActive(false);
            FinishedImage.SetActive(true);
            StarKef1Game.SetActive(false);
            EndKef1NextGame.SetActive(true);
        }
        if (Welcome_Panel != null) {
            bool isActive = Welcome_Panel.activeSelf;
            Welcome_Panel.SetActive(!isActive);
        }
    }

    
    public Sprite imagesQ3;

    private bool LoadQnA() {
        bool endKef = false;
        if (row < Choices.GetLength(0)) {
            TableQuestion.text = Questions[line++].ToString();
            Answer1Text.text = Choices[row, column++].ToString();
            Answer2Text.text = Choices[row, column++].ToString();
            Answer3Text.text = Choices[row++, column].ToString(); column = 0;
        } else if (line < Questions.Length) { //continue with Photo answers
            TableQuestion.text = Questions[line++].ToString();
            Answer1.GetComponent<Image>().material = null; Answer1Text.text = "";
            Answer1.image.sprite = imagesQ3;
        }
        else {
            endKef = true;
        }
        return endKef;
    }
}