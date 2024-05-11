using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButtonPress()
    {
        GlobalVar.gamePause = true;
        pausePanel.SetActive(true);
    }

    public void ResumeButtonPress()
    {
        GlobalVar.gamePause = false;
        pausePanel.SetActive(false);
    }

    public void BackToMenuButtonPress()
    {
        SceneManager.LoadScene("Menu");
    }
}
