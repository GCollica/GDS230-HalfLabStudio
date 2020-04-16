using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject[] mainMenuButtons;
    public Animator titleAnimator;
    public Sprite titleBGSprite;
    public Sprite blankBGSprite;
    public GameObject backgroundGameObject;
    
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LvlSelect() 
    {
        HideTitleButtons();
        StartAnimation(2);
    }
    public void BackToMainMenu() 
    {        
        HidePlayButtons();
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
        if(mainMenuButtons[0].activeInHierarchy == true && mainMenuButtons[2].activeInHierarchy == true)
        {
            mainMenuButtons[0].SetActive(false);
            mainMenuButtons[2].SetActive(false);
        }
    }

    public void ShowTitleButtons()
    {
        if (mainMenuButtons[0].activeInHierarchy == false && mainMenuButtons[2].activeInHierarchy == false)
        {
            mainMenuButtons[0].SetActive(true);
            mainMenuButtons[2].SetActive(true);
        }       
    }

    public void HidePlayButtons()
    {
        if(mainMenuButtons[1].activeInHierarchy == true)
        {
            mainMenuButtons[1].SetActive(false);
        }
    }

    public void ShowPlayButtons()
    {
        if(mainMenuButtons[1].activeInHierarchy == false)
        {
            mainMenuButtons[1].SetActive(true);
        }
    }

    /*public void SetBackground(int sprite)
    {
        if(sprite == 1)
        {
            backgroundGameObject.GetComponent<SpriteRenderer>().sprite = titleBGSprite;
        }

        if(sprite == 2)
        {
            backgroundGameObject.GetComponent<SpriteRenderer>().sprite = blankBGSprite;
        }
    }*/
}
