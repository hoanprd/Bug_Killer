using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement2 : MonoBehaviour
{
    public GameObject bug;
    public AudioSource[] FXSound;
    public Transform target;
    public AudioSource hurtFX, hitFX;

    public float speed;
    public bool negate, pointStop;

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
            GlobalVar.playerHP -= 30;
            Destroy(bug.gameObject);
        }
        if (collision.gameObject.CompareTag("player"))
        {
            if (!pointStop)
            {
                hurtFX.Play();
                pointStop = true;
                GlobalVar.gamePoint += 20;
            }
            negate = true;
            StartCoroutine(DelayDestroy());
        }
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(bug.gameObject);
    }
}
