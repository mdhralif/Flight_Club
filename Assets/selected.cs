using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selected : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI select1;
    public TextMeshProUGUI select2;
    [SerializeField] public static bool isPlayer1Selected, isPlayer2Selected, isone;
    void Start()
    {
        isPlayer2Selected = false;
        isPlayer1Selected = false;
        staticClass.isFirst = false;
        isone = false;
    }

    void Update()
    {
        selection();
        selection2();
    }
    public void selection()
    {
        if (isbothPlayerSelected())
        {
            ChangeScene();
        }
    }
    public bool isbothPlayerSelected()
    {
        return isPlayer1Selected && isPlayer2Selected;
    }
    void selection2()
    {
        if (staticClass.player1selected == 0 && staticClass.isFirst && staticClass.keyboardSelect)
        {
            SceneManager.LoadScene("Alif_keyboard");
        }
        else if (staticClass.player1selected == 0 && staticClass.isFirst && !staticClass.keyboardSelect)
        {
            SceneManager.LoadScene("Alif_gamepad");
        }
        else if (staticClass.player1selected == 1 && staticClass.isFirst && staticClass.keyboardSelect)
        {
            SceneManager.LoadScene("Emon_keyboard");
        }
        else if (staticClass.player1selected == 1 && staticClass.isFirst && !staticClass.keyboardSelect)
        {
            SceneManager.LoadScene("emon_gamepad");
        }
    }
    public void ChangeScene()
    {
        
        if (staticClass.player1selected == 0 && staticClass.player2selected == 1)
        {
            SceneManager.LoadScene("akvseg"); //alif vs emon
        }
        else if (staticClass.player1selected == 1 && staticClass.player2selected == 0)
        {
            SceneManager.LoadScene("agvsek"); //emon vs alif
        }
        
    }
    public void selectPlayer1()
    {
        if (isPlayer2Selected && staticClass.player2selected==staticClass.player1selected)
        {
            return;
        }
        isPlayer1Selected = true;
        select1.text = "selected";
    }
    public void selectPlayer2()
    {
        if(isPlayer1Selected && staticClass.player2selected == staticClass.player1selected)
        {
            return;
        }
        isPlayer2Selected = true;
        select2.text = "selected";
    }
    public void keyboardSelected()
    {
        staticClass.keyboardSelect = true;
        SceneManager.LoadScene("oneSelection"); 
    }
    public void gamepadSelected()
    {
        staticClass.keyboardSelect = false;
        SceneManager.LoadScene("oneSelection");

    }
    public void singlePlayerSelection()
    {
        staticClass.isFirst = true;
    }
}
