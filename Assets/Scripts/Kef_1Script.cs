using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Kef_1Script : MonoBehaviour
{

    string[] Questions = {
        "Ποιες ομοιότητες παρατηρείτε ανάμεσα στην Αμερικανική "+
            "και την Γαλλική Επανάσταση;",
        "Ποια θεωρούνται τα σημαντικότερα ανθρώπινα δικαιώματα με βάση "+
                "τα κείμενα των δύο πηγών; Τι πιστεύουμε σήμερα;" +
        "Ετσι με αρέσει"
    };
    string[,] Answers = { { "1Anse1 ", "1Anse2 ", "1Anse3" }, 
                          { "2Anse1 ", "2Anse2 ", "3Anse3" },
                          { "3Anse1 ", "3Anse2 ", "3Anse3" }
    };

    public TMP_Text TableText;
    public TMP_Text Answer1Text;
    public TMP_Text Answer2Text;
    public TMP_Text Answer3Text;

    void Start(){

        TableText.text = Questions[0].ToString();
        Answer1Text.text = Answers[0, 0].ToString();
        Answer2Text.text = Answers[0, 1].ToString();
        Answer3Text.text = Answers[0, 2].ToString();
    }

    void Update(){        
    }

    public void Piso(){
        SceneManager.LoadScene("MenuScene");
    }
}
