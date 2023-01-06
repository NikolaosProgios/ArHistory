using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Kef_5Script : MonoBehaviour
{
    public GameObject Welcome_Panel, WelcomeImage, GoodBye�mage,
    StarKef5Game, EndKef5NextGame;
    public TMP_Text TitlePanel;

    public GameObject AnswersCanvas;
    public TMP_Text TableQuestion,
            Answer1Text, Answer2Text, Answer3Text;
    public Button Answer1btn, Answer2btn, Answer3btn;
    int line, row_txt, column, row_img, correctAnswersCounter;

    string[] Questions = {
        "����� ����� �� ���������� ������� ���� ������ ���� ��� ��������� ���������; "
        ,"���� ���� �� ����� ��� ������������ ��������� ��� ��� ������; �� ��� �������� � ���� 1."
        ,"���� ����� ��� ��������� ���������� ���� ���������������� (14), ����� ����, ������, ����, ������"+
         "����� ����� � ������ ������;"
        ,"Photo Answers1","Photo Answers2","Photo Answers3",
    };

    string[,] Choices = { { "1Anse1", "1Anse2", "1Anse3" },
                          { "����", "�������", "�������" },
                          { "3Anse1", "3Anse2", "3Anse3" }
    };
    int[] correctAnswers = { 1, 2, 2, 1, 2, 2 };


}
