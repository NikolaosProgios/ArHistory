using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Kef_1Script : MonoBehaviour{

    public GameObject Welcome_Panel, WelcomeImage, GoodByeΙmage,
            StarKef1Game, EndKef1NextGame;
    public TMP_Text TitlePanel;

    public GameObject AnswersCanvas;
    public TMP_Text PanelQuestion,
            Answer1Text, Answer2Text, Answer3Text;
    public Button Answer1btn, Answer2btn, Answer3btn;

    private int line, row_txt, column, row_img, correctAnsw;

    string[] Questions = {
        "Ποιες ομοιότητες παρατηρείτε ανάμεσα στην Αμερικανική "+
            "και την Γαλλική Επανάσταση;",
        "Ποια θεωρούνται τα σημαντικότερα ανθρώπινα δικαιώματα με βάση "+
                "τα κείμενα των δύο πηγών; Τι πιστεύουμε σήμερα;" ,
        "Ερώτηση 3η",
    };
    string[,] Choices = { { "1Anse1 ", "1Anse2 ", "1Anse3" },
                          { "2Anse1 ", "2Anse2 ", "2Anse3" },
                          { "3Anse1 ", "3Anse2 ", "3Anse3" }
    };
    int[] correctAnswers = {1,2,2,};

    public void Start() => ShowHidePanel("Welcome");

    public void Piso() => SceneManager.LoadScene("MenuScene");

    public void StartOf(){
        ShowHidePanel("Hide");
        LoadQnA();
    }
    private void ShowHidePanel(string ComeOrBye) {
        if (Welcome_Panel != null) {
            bool isActive = Welcome_Panel.activeSelf;
            Welcome_Panel.SetActive(!isActive);
        }
        if (ComeOrBye== "Welcome") {
            TitlePanel.text = "Καλωσήρθες στην 1η Ενότητα του παιχνιδού μας";
            WelcomeImage.SetActive(true);
            GoodByeΙmage.SetActive(false);
            StarKef1Game.SetActive(true);
            EndKef1NextGame.SetActive(false);
        }else if (ComeOrBye == "GoodBye") {
            TitlePanel.text = "Ολοκλήρωσες την 1η Ενότητα του παιχνιδού μας";
            WelcomeImage.SetActive(false);
            GoodByeΙmage.SetActive(true);
            StarKef1Game.SetActive(false);
            EndKef1NextGame.SetActive(true);
        }
    }
    public async void PressedAnswer(int choice) {
        if (choice == correctAnswers[--line]) {
            correctAnsw++;           
        } line++;
        if (LoadQnA()) {
            PanelQuestion.text = "Τέλος 1ης Ενότητας."
                + "\nΣωστες Απαντήσεις: " + correctAnsw
                + "\nΛανθασμένες Απαντήσεις: " + (Questions.Length-correctAnsw);
            AnswersCanvas.SetActive(false);
            await Task.Delay(3000);
            ShowHidePanel("GoodBye");
        }
    }   
    
    public void OpenKefN(int n) => SceneManager.LoadScene("Kef_" + n);

    private bool LoadQnA() {
        bool endKef = false;
        if (row_txt < Choices.GetLength(0)) {
            PanelQuestion.text = Questions[line++].ToString();
            Answer1Text.text = Choices[row_txt, column++].ToString();
            Answer2Text.text = Choices[row_txt, column++].ToString();
            Answer3Text.text = Choices[row_txt++, column].ToString(); column = 0;
        }
        else {
            endKef = true;
        }
        return endKef;
    }
}