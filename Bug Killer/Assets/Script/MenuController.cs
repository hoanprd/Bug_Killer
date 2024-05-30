using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject settingPanel;
    public AudioSource clickFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPress()
    {
        clickFX.Play();
        GlobalVar.gamePoint = 0;
        GlobalVar.playerHP = 100;
        GlobalVar.gamePause = false;
        GlobalVar.gameOver = false;
        SceneManager.LoadScene("Main");
    }

    public void SettingPress()
    {
        clickFX.Play();
        settingPanel.SetActive(true);
    }

    public void ExitPress()
    {
        clickFX.Play();
        Application.Quit();
    }

    public void ChangeScreenRESFull()
    {
        Resolution resolution = Screen.currentResolution;

        Screen.SetResolution(resolution.width, resolution.height, true);
    }

    public void ChangeScreenRESWin()
    {
        Screen.SetResolution(1280, 720, false);
    }

    public void CloseSettingPress()
    {
        clickFX.Play();
        settingPanel.SetActive(false);
    }
}