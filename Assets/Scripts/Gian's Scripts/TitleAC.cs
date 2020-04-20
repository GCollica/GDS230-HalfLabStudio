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

    public void HideTitleButtons()
    {
        menuButtonsScript.HideTitleButtons();
    }

    public void ShowLVL1Buttons()
    {
        menuButtonsScript.ShowLVL1Buttons();
    }

    public void HideLVL1Buttons()
    {
        menuButtonsScript.HideLVL1Buttons();
    }

    public void ShowLVL2Buttons()
    {
        menuButtonsScript.ShowLVL2Buttons();
    }

    public void HideLVL2Buttons()
    {
        menuButtonsScript.HideLVL2Buttons();
    }

    public void ShowLVL3Buttons()
    {
        menuButtonsScript.ShowLVL3Buttons();
    }

    public void HideLVL3Buttons()
    {
        menuButtonsScript.HideLVL3Buttons();
    }
}
