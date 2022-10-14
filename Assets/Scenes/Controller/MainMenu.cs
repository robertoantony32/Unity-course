using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame(){
        SceneManager.LoadScene("Level 1");    
    }

    public void Exit()
    {
        Application.Quit();
    }


    public void GoBackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
