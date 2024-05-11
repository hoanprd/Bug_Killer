using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject settingPanel;

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
        SceneManager.LoadScene("Main");
    }

    public void SettingPress()
    {
        settingPanel.SetActive(true);
    }

    public void ExitPress()
    {
        Application.Quit();
    }

    public void CloseSettingPress()
    {
        settingPanel.SetActive(false);
    }
}