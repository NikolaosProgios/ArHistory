using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Kef_3Script : MonoBehaviour {

    public GameObject Welcome_Panel, WelcomeImage, GoodBye�mage,
        StarKef3Game, EndKef3NextGame;
    public TMP_Text TitlePanel;

    public GameObject AnswersCanvas;
    public TMP_Text TableQuestion,
            Answer1Text, Answer2Text, Answer3Text;
    public Button Answer1btn, Answer2btn, Answer3btn;
    int line, row_txt, column, row_img, correctAnsw;

    string[] Questions = {
        "����� ���� �� �������� ��� ������������������ ��� ����� ���������� " +
            "�������� ������; �� ��� �������� ��� � ������.",
        "����� ���� � ���������� ��� ��������� ����������� ������� �� ��� �����������; (���� 1)",
        "������� 3�",
        "Photo Answers1","Photo Answers2","Photo Answers3",
    };

    string[,] Choices = { { "1Anse1 ", "1Anse2 ", "1Anse3" },
                          { "2Anse1 ", "2Anse2 ", "2Anse3" },
                          { "3Anse1 ", "3Anse2 ", "3Anse3" }
    };
    int[] correctAnswers = { 1, 2, 2, 1, 2, 2 };

    void Start() => ShowHidePanel("Welcome");

    public void Startof() {
        ShowHidePanel("");
        LoadQnA();
    }

    public async void PressedAnswer(int choice) {
        if (choice == correctAnswers[--line]) {
            correctAnsw++;
        } line++;
        if (LoadQnA()) {
            TableQuestion.text = "����� 3�� ��������."
                + "\n������ ����������: " + correctAnsw
                + "\n����������� ����������: " + (Questions.Length - correctAnsw);
            AnswersCanvas.SetActive(false);
            await Task.Delay(3000);
            ShowHidePanel("GoodBye");
        }
    }

    public void Piso() => SceneManager.LoadScene("MenuScene");

    public void OpenKefN(int n) => SceneManager.LoadScene("Kef_" + n);

    private void ShowHidePanel(string ComeOrBye) {
        if (ComeOrBye == "Welcome") {
            TitlePanel.text = "���������� ���� 3� ������� ��� ��������� ���";
            WelcomeImage.SetActive(true);
            GoodBye�mage.SetActive(false);
            StarKef3Game.SetActive(true);
            EndKef3NextGame.SetActive(false);
        }
        else if (ComeOrBye == "GoodBye") {
            TitlePanel.text = "����������� ��� 3� ������� ��� ��������� ���";
            WelcomeImage.SetActive(false);
            GoodBye�mage.SetActive(true);
            StarKef3Game.SetActive(false);
            EndKef3NextGame.SetActive(true);
        }
        if (Welcome_Panel != null) {
            bool isActive = Welcome_Panel.activeSelf;
            Welcome_Panel.SetActive(!isActive);
        }
    }

    public Sprite[] imagesQ1, imagesQ2, imagesQ3 = new Sprite[3];

    private bool LoadQnA(){
        bool endKef = false;
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
            endKef = true;
        }
        return endKef;
    }
}
