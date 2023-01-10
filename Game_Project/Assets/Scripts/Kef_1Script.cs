using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Collections.Generic;

public class Kef_1Script : MonoBehaviour {

    public GameObject Welcome_Panel, WelcomeImage, GoodByeΙmage,
            StarKef1Game, EndKef1NextGame;
    public TMP_Text TitlePanel;

    public GameObject AnswersCanvas;
    public TMP_Text TableQuestion;
    public List<TMP_Text> AnswersText = new List<TMP_Text>();

    private int line, row_txt, column, correctAnswersCounter;

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
    int[] correctAnswers = {0,1,1};

    public void Start() => ShowHidePanel("Welcome");

    public void Piso() => SceneManager.LoadScene("MenuScene");

    public void OpenKefN(int n) => SceneManager.LoadScene("Kef_" + n);

    public void StartOf(){
        ShowHidePanel("");
        LoadQnA();
    }

    public async void PressedAnswer(int choice) {
        CorrectOrWrongChoice(choice);
        if (!LoadQnA()) {
            await Task.Delay(300);
            AnswersCanvas.SetActive(false);
            TableQuestion.text = "Τέλος 1ης Ενότητας."
                + "\nΣωστες Απαντήσεις: " + correctAnswersCounter
                + "\nΛανθασμένες Απαντήσεις: " + (Questions.Length-correctAnswersCounter);
            await Task.Delay(2700);
            ShowHidePanel("GoodBye");
        }
    }

    private void ShowHidePanel(string ComeOrBye) {
        if (Welcome_Panel != null) {
            bool isActive = Welcome_Panel.activeSelf;
            Welcome_Panel.SetActive(!isActive);
        }
        if (ComeOrBye== "Welcome") {
            TitlePanel.text = "Καλωσήρθες στην 1η Ενότητα του παιχνιδού μας";
            switchWelcomeGoodByePanel(true);
        }
        else if (ComeOrBye == "GoodBye") {
            TitlePanel.text = "Ολοκλήρωσες την 1η Ενότητα του παιχνιδού μας";
            switchWelcomeGoodByePanel(false);
        }
    }

    private void switchWelcomeGoodByePanel(bool boolean) {
        WelcomeImage.SetActive(boolean);
        GoodByeΙmage.SetActive(!boolean);
        StarKef1Game.SetActive(boolean);
        EndKef1NextGame.SetActive(!boolean);
    }

    private bool LoadQnA() {
        if (row_txt < Choices.GetLength(0)) {
            TableQuestion.text = Questions[line++].ToString();
            AnswersText.ForEach(answersText => answersText.text = Choices[row_txt, column++].ToString());
            column = 0; row_txt++;
        }
        else {
            return false;
        }
        return true;
    }

    private void CorrectOrWrongChoice(int choice) {
        if (choice == correctAnswers[--line]) {
            correctAnswersCounter++;
        }
        line++;
    }
}