using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject[] mainMenuButtons;
    public GameObject bannerAds;
    public Animator titleAnimator;
    public Sprite titleBGSprite;
    public Sprite blankBGSprite;
    public GameObject backgroundGameObject;
    
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Lvl1Select() 
    {
        HideTitleButtons();
        HideLVL2Buttons();
        StartAnimation(2);
    }

    public void Lvl2Select()
    {
        HideLVL1Buttons();
        HideLVL3Buttons();
        StartAnimation(3);
    }

    public void Lvl3Select()
    {
        HideLVL2Buttons();
        StartAnimation(4);
    }
    public void BackToMainMenu() 
    {        
        HideLVL1Buttons();
        StartAnimation(1);
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

    public void StartAnimation(int targetScreen)
    {
        titleAnimator.SetBool("ChangePage", true);
        titleAnimator.SetInteger("TargetScreen", targetScreen);
    }

    public void HideTitleButtons()
    {
        if(mainMenuButtons[0].activeInHierarchy == true && mainMenuButtons[1].activeInHierarchy == true && mainMenuButtons[5].activeInHierarchy == true && bannerAds.activeInHierarchy == true)
        {
            mainMenuButtons[0].SetActive(false);
            mainMenuButtons[1].SetActive(false);
            mainMenuButtons[5].SetActive(false);
            bannerAds.SetActive(false);
        }
    }

    public void ShowTitleButtons()
    {
        if (mainMenuButtons[0].activeInHierarchy == false && mainMenuButtons[1].activeInHierarchy == false && mainMenuButtons[5].activeInHierarchy == false && bannerAds.activeInHierarchy == false)
        {
            mainMenuButtons[0].SetActive(true);
            mainMenuButtons[1].SetActive(true);
            mainMenuButtons[5].SetActive(true);
            bannerAds.SetActive(true);
        }       
    }

    public void HideLVL1Buttons()
    {
        if(mainMenuButtons[2].activeInHierarchy == true)
        {
            mainMenuButtons[2].SetActive(false);
        }
    }

    public void ShowLVL1Buttons()
    {
        if(mainMenuButtons[2].activeInHierarchy == false)
        {
            mainMenuButtons[2].SetActive(true);
        }
    }

    public void HideLVL2Buttons()
    {
        if(mainMenuButtons[3].activeInHierarchy == true)
        {
            mainMenuButtons[3].SetActive(false);
        }
    }

    public void ShowLVL2Buttons()
    {
        if (mainMenuButtons[3].activeInHierarchy == false)
        {
            mainMenuButtons[3].SetActive(true);
        }
    }

    public void HideLVL3Buttons()
    {
        if(mainMenuButtons[4].activeInHierarchy == true)
        {
            mainMenuButtons[4].SetActive(false);
        }
    }

    public void ShowLVL3Buttons()
    {
        if(mainMenuButtons[4].activeInHierarchy == false)
        {
            mainMenuButtons[4].SetActive(true);
        }
    }

    public void ShowVolSliders()
    {
        if(mainMenuButtons[5].activeInHierarchy == false)
        {
            mainMenuButtons[5].SetActive(true);
        }
    }

    public void HideVolSliders()
    {
        if (mainMenuButtons[5].activeInHierarchy == true)
        {
            mainMenuButtons[5].SetActive(false);
        }
    }



}
