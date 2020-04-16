using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAC : MonoBehaviour
{

    private Animator titleAnimator;
    public MainMenuButtons menuButtonsScript;

    // Start is called before the first frame update
    void Awake()
    {
        titleAnimator = this.gameObject.GetComponent<Animator>();
    }

    public void ResetAnimState()
    {
        titleAnimator.SetBool("ChangePage", false);
    }

    public void ShowTitleButtons()
    {
        menuButtonsScript.ShowTitleButtons();
    }

    public void ShowPlayButtons()
    {
        menuButtonsScript.ShowPlayButtons();
    }

    public void HideTitleButtons()
    {
        menuButtonsScript.HideTitleButtons();
    }

    public void HidePlayButtons()
    {
        menuButtonsScript.HidePlayButtons();
    }

    /*public void SetBackground(int sprite)
    {
       menuButtonsScript.SetBackground(sprite);
    }*/
}
