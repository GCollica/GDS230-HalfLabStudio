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

    public void resetAnimState()
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
}
