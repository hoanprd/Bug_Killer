using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement3 : MonoBehaviour
{
    public GameObject bug;
    public AudioSource[] FXSound;
    public Transform target;
    public AudioSource hurtFX, hitFX;

    public int bugHP;
    public float speed;
    public bool negate, pointStop;
    private float newRandomX, newRandomY;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("khoa").transform;

        for (int i = 0; i < FXSound.Length; i++)
        {
            FXSound[i].volume = PlayerPrefs.GetFloat("SFX");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!negate && !GlobalVar.gamePause)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            bug.transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("khoa"))
        {
            hitFX.Play();
            GlobalVar.playerHP -= 50;
            Destroy(bug.gameObject);
        }
        if (collision.gameObject.CompareTag("player") && !pointStop)
        {
            pointStop = true;
            if (bugHP == 0)
            {
                hurtFX.Play();
                GlobalVar.gamePoint += 50;
                negate = true;
                StartCoroutine(DelayDestroy());
            }
            else
            {
                hurtFX.Play();
                bugHP -= 1;
                if (newRandomX >= 0)
                {
                    newRandomX = 5f;
                }
                else
                {
                    newRandomX = -5f;
                }
                newRandomY = Random.Range(1, 3);
                bug.transform.position = new Vector3(newRandomX, newRandomY, 0);
                pointStop = false;
            }
        }
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(bug.gameObject);
    }
}
