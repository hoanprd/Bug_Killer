using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpam : MonoBehaviour
{
    public GameObject bugPrefab;
    public Transform root;
    public float timer, randomDir, randomX, randomY, tempY;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && !GlobalVar.gamePause)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                BugSpamUpdate();
            }
        }
    }

    public void BugSpamUpdate()
    {
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

        Instantiate(bugPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity, root);

        timer = 5f;
    }
}
