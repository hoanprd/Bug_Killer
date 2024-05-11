using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalVar : MonoBehaviour
{
    public Text pointText, hpText;

    public static int gamePoint, playerHP;
    public static bool gameOver, gamePause;

    // Start is called before the first frame update
    void Start()
    {
        gamePoint = 0;
        playerHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP < 0)
        {
            playerHP = 0;
        }

        hpText.text = "HP: " + playerHP + "/100";
        pointText.text = "Point: " + gamePoint;
    }
}
