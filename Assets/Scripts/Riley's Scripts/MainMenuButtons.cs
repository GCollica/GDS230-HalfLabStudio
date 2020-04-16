using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject[] mainMenuButtons;
    public Animator titleAnimator;
    
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LvlSelect() 
    {
        HideTitleButtons();
        StartAnimation();
    }
    public void BackToMainMenu() 
    {
        HidePlayButtons();
        ShowTitleButtons();
    }

    public void LoadLvl1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLvl2()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadLvl3() 
    {
        SceneManager.LoadScene(5);
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene(2);
    }

    public void StartAnimation()
    {
        titleAnimator.SetBool("ChangePage", true);
    }

    public void HideTitleButtons()
    {
        mainMenuButtons[0].SetActive(false);
        mainMenuButtons[2].SetActive(false);
    }

    public void ShowTitleButtons()
    {
        mainMenuButtons[0].SetActive(true);
        mainMenuButtons[2].SetActive(true);
    }

    public void HidePlayButtons()
    {
        mainMenuButtons[1].SetActive(false);
    }

    public void ShowPlayButtons()
    {
        mainMenuButtons[1].SetActive(true);
    }


}
