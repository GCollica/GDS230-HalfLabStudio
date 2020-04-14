using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject[] mainMenuButtons;
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LvlSelect() 
    {
        mainMenuButtons[0].SetActive(false);
        mainMenuButtons[1].SetActive(true);
    }
    public void BackToMainMenu() 
    {
        mainMenuButtons[0].SetActive(true);
        mainMenuButtons[1].SetActive(false);
    }

    public void LoadLvl1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLvl2()
    {
        SceneManager.LoadScene(4);
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene(2);
    }
}
