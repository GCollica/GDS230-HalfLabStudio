using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Options_Menu_Script : MonoBehaviour
{
    public AudioMixer GameMixer; // a reference to the game audio mixer
    public Slider masterVolumeSlider; // ui master volume slider
    public Slider musicVolumeSlider; // ui music volume slider
    public Slider effectVolumeSlider; // ui effect volume slider
    public Text masterPerText; // ui master % text
    public Text musicPerText; // ui music % text
    public Text effectPerText; // ui effect % text


    void Start()
    {
        //setting the volumes to Player prefence
        masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume", 1);
        masterPerText.text = Mathf.RoundToInt(masterVolumeSlider.value * 100) + "%";
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 1);
        musicPerText.text = Mathf.RoundToInt(musicVolumeSlider.value * 100) + "%";
        effectVolumeSlider.value = PlayerPrefs.GetFloat("soundEffectVolume", 1);
        effectPerText.text = Mathf.RoundToInt(effectVolumeSlider.value * 100) + "%";

    }

    public void SetMasterVolume(float vol) //dynamic float master volume                                                                                                             
    {
        GameMixer.SetFloat("masterVolume", Mathf.Log10(vol) * 20); //change actaul volume
        PlayerPrefs.SetFloat("masterVolume", vol); // save as preference
        masterPerText.text = Mathf.RoundToInt(vol * 100) + "%"; // change percentage text

    }
    public void SetMusicVolume(float vol) //dynamic float music volume
    {
        GameMixer.SetFloat("musicVolume", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("musicVolume", vol);
        musicPerText.text = Mathf.RoundToInt(vol * 100) + "%";
    }
    public void SetEffectVolume(float vol) //dynamic float effect volume
    {
        GameMixer.SetFloat("soundEffectVolume", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("soundEffectVolume", vol);
        effectPerText.text = Mathf.RoundToInt(vol * 100) + "%";
    }
    public void BackButton() //back button
    {
        SceneManager.LoadScene(0);// load main menu
    }
    public void ComButton() //compendium button
    {
        SceneManager.LoadScene(3);// load disease compendium
    }


}
