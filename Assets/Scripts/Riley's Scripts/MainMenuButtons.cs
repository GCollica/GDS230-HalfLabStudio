using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
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
