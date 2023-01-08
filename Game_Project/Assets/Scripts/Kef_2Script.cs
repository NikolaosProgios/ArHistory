using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Collections.Generic;

public class Kef_2Script : MonoBehaviour {
	
    public GameObject Welcome_Panel, WelcomeImage, GoodBye�mage,
            StarKef2Game, EndKef2NextGame;
    public TMP_Text TitlePanel;

    public GameObject AnswersCanvas;
    public TMP_Text TableQuestion;
    public List<TMP_Text> AnswersText = new List<TMP_Text>();
    public List<Button> AnswersBtn = new List<Button>();

    int line, row_txt, column, row_img, correctAnswersCounter;

    string[] Questions = {
        "��� ������ ������ �� ��������� ���� ������� �� ���������� ����������;",
        "���� ���� �� �������� ����� ��� ���� ��������� �� ���� �� ������� ��� �����;",
        "������� 3�",
        "Photo Answers1","Photo Answers2","Photo Answers3",
    };
    string[,] Choices = { { "1Anse1 ", "1Anse2 ", "1Anse3" },
                          { "2Anse1 ", "2Anse2 ", "2Anse3" },
                          { "3Anse1 ", "3Anse2 ", "3Anse3" }
    };
    public Sprite[] imagesQ1, imagesQ2, imagesQ3 = new Sprite[3];
    int[] correctAnswers = { 0, 1, 1, 0, 1, 1 };

    public void Start() => ShowHidePanel("Welcome");

    public void Piso() => SceneManager.LoadScene("MenuScene");

    public void OpenKefN(int n) => SceneManager.LoadScene("Kef_" + n);

    public void Startof() {
        ShowHidePanel("");
        LoadQnA();
    }

    public async void PressedAnswer(int choice) {
        CorrectOrWrongChoice(choice);
        if (!LoadQnA()) {
            await Task.Delay(300);
            AnswersCanvas.SetActive(false);
            TableQuestion.text = "����� 2�� ��������."
                + "\n������ ����������: " + correctAnswersCounter
                + "\n����������� ����������: " + (Questions.Length - correctAnswersCounter);            
            await Task.Delay(2700);
            ShowHidePanel("GoodBye");
        }
    }

    private void ShowHidePanel(string ComeOrBye) {
        if (Welcome_Panel != null) {
            bool isActive = Welcome_Panel.activeSelf;
            Welcome_Panel.SetActive(!isActive);
        }
        if (ComeOrBye == "Welcome") {
            TitlePanel.text = "���������� ���� 2� ������� ��� ��������� ���";
            WelcomeImage.SetActive(true);
            GoodBye�mage.SetActive(false);
            StarKef2Game.SetActive(true);
            EndKef2NextGame.SetActive(false);
        }
        else if (ComeOrBye == "GoodBye") {
            TitlePanel.text = "����������� ��� 2� ������� ��� ��������� ���";
            WelcomeImage.SetActive(false);
            GoodBye�mage.SetActive(true);
            StarKef2Game.SetActive(false);
            EndKef2NextGame.SetActive(true);
        }
    }

    private bool LoadQnA() {
        if (row_txt < Choices.GetLength(0)) {
            TableQuestion.text = Questions[line++].ToString();
            AnswersText[0].text = Choices[row_txt, column++].ToString();
            AnswersText[1].text = Choices[row_txt, column++].ToString();
            AnswersText[2].text = Choices[row_txt++, column].ToString(); column = 0;
        }
        else if (line < Questions.Length) { //continue with Photo answers
            TableQuestion.text = Questions[line++].ToString();
            AnswersBtn[0].GetComponent<Image>().material = null; AnswersText[0].text = "";
            AnswersBtn[1].GetComponent<Image>().material = null; AnswersText[1].text = "";
            AnswersBtn[2].GetComponent<Image>().material = null; AnswersText[2].text = "";
            AnswersBtn[0].image.sprite = imagesQ1[row_img];
            AnswersBtn[1].image.sprite = imagesQ2[row_img];
            AnswersBtn[2].image.sprite = imagesQ3[row_img++];
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