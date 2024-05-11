using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpam : MonoBehaviour
{
    public GameObject[] bugPrefab;
    public Transform root;
    public int randomSpamRange, stateGame;
    public float timer, randomDir, randomX, randomY, tempY;
    public bool stopState2, stopState3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && !GlobalVar.gamePause  && !GlobalVar.gameOver)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                BugSpamUpdate();
            }
        }

        if (GlobalVar.gamePoint >= 50 && !stopState2 && !GlobalVar.gamePause && !GlobalVar.gameOver)
        {
            stopState2 = true;
            randomSpamRange = 2;
        }
        else if (GlobalVar.gamePoint >= 100 && !stopState3 && !GlobalVar.gamePause && !GlobalVar.gameOver)
        {
            stopState3 = true;
            randomSpamRange = 3;
        }

    }

    public void BugSpamUpdate()
    {
        int bugID;
        bugID = Random.Range(0, randomSpamRange);
        randomDir = Random.Range(0, 2);

        if (randomDir == 0)
        {
            randomX = -6f;
        }
        else
        {
            randomX = 6f;
        }

        randomY = Random.Range(1, 6);
        while (randomY == tempY)
        {
            randomY = Random.Range(1, 6);
        }
        tempY = randomY;

        Instantiate(bugPrefab[bugID], new Vector3(randomX, randomY, 0), Quaternion.identity, root);

        timer = 5f;
    }
}
