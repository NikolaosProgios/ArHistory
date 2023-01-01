using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Kef_2Script : MonoBehaviour {
	
    public GameObject Welcome_Panel, WelcomeImage, GoodByeΙmage,
            StarKef2Game, EndKef2NextGame;
    public TMP_Text TitlePanel;

    public GameObject AnswersCanvas;
    public Button Answer1btn, Answer2btn, Answer3btn;
    public TMP_Text TableQuestion,
            Answer1Text, Answer2Text, Answer3Text;

    int line, row_txt, column, row_img, correctAnswersCounter;

    string[] Questions = {
        "Για ποιους λόγους οι Σουλιώτες ήταν γνωστοί ως ικανότατοι πολεμιστές;",
        "Ποιο ήταν το υπέρτατο αγαθό για τους Σουλιώτες με βάση τα κείμενα των πηγών;",
        "Ερώτηση 3η",
        "Photo Answers1","Photo Answers2","Photo Answers3",
    };

    string[,] Choices = { { "1Anse1 ", "1Anse2 ", "1Anse3" },
                          { "2Anse1 ", "2Anse2 ", "2Anse3" },
                          { "3Anse1 ", "3Anse2 ", "3Anse3" }
    };
    int[] correctAnswers = {1, 2, 2, 1, 2, 2};

    public Sprite[] imagesQ1, imagesQ2, imagesQ3 = new Sprite[3];

    public void Start() => ShowHidePanel("Welcome");

    public void Piso() => SceneManager.LoadScene("MenuScene");

    public void OpenKefN(int n) => SceneManager.LoadScene("Kef_" + n);

    public void Startof() {
        ShowHidePanel("");
        LoadQnA();
    }

    private void ShowHidePanel(string ComeOrBye) {
        if (Welcome_Panel != null) {
            bool isActive = Welcome_Panel.activeSelf;
            Welcome_Panel.SetActive(!isActive);
        }
        if (ComeOrBye == "Welcome") {
            TitlePanel.text = "Καλωσήρθες στην 2η Ενότητα του παιχνιδού μας";
            WelcomeImage.SetActive(true);
            GoodByeΙmage.SetActive(false);
            StarKef2Game.SetActive(true);
            EndKef2NextGame.SetActive(false);
        }
        else if (ComeOrBye == "GoodBye") {
            TitlePanel.text = "Ολοκλήρωσες την 2η Ενότητα του παιχνιδού μας";
            WelcomeImage.SetActive(false);
            GoodByeΙmage.SetActive(true);
            StarKef2Game.SetActive(false);
            EndKef2NextGame.SetActive(true);
        }
    }

    private bool LoadQnA() {
        if (row_txt < Choices.GetLength(0)) {
            TableQuestion.text = Questions[line++].ToString();
            Answer1Text.text = Choices[row_txt, column++].ToString();
            Answer2Text.text = Choices[row_txt, column++].ToString();
            Answer3Text.text = Choices[row_txt++, column].ToString(); column = 0;
        }
        else if (line < Questions.Length) { //continue with Photo answers
            TableQuestion.text = Questions[line++].ToString();
            Answer1btn.GetComponent<Image>().material = null; Answer1Text.text = "";
            Answer2btn.GetComponent<Image>().material = null; Answer2Text.text = "";
            Answer3btn.GetComponent<Image>().material = null; Answer3Text.text = "";
            Answer1btn.image.sprite = imagesQ1[row_img];
            Answer2btn.image.sprite = imagesQ2[row_img];
            Answer3btn.image.sprite = imagesQ3[row_img++];
        }
        else {
            return false;
        }
        return true;
    }

    public async void PressedAnswer(int choice) {
        if (choice == correctAnswers[--line]){
            correctAnswersCounter++;
        } line++;
        if (!LoadQnA()) {
            TableQuestion.text = "Τέλος 2ης Ενότητας."
                + "\nΣωστες Απαντήσεις: " + correctAnswersCounter
                + "\nΛανθασμένες Απαντήσεις: " + (Questions.Length - correctAnswersCounter);
            AnswersCanvas.SetActive(false);
            await Task.Delay(3000);
            ShowHidePanel("GoodBye");
        }
    }
}