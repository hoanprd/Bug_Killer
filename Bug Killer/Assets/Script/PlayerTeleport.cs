using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public Transform player;
    public float randomX, randomY;
    public bool stopTeleport;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVar.gamePoint % 50 == 0 && !stopTeleport)
        {
            stopTeleport = true;
            randomX = Random.Range(-3, 4);
            randomY = Random.Range(0, 3);

            if (randomX == -3)
            {
                randomX = -2.5f;
            }
            if (randomX == 3)
            {
                randomX = 2.5f;
            }

            player.transform.position = new Vector3(randomX, randomY, 0);
        }

        if (GlobalVar.gamePoint % 50 != 0)
        {
            stopTeleport = false;
        }
    }
}
