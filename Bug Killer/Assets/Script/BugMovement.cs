using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour
{
    public GameObject bug;
    public Transform target;

    public float speed;
    public bool negate, pointStop;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("khoa").transform;
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
            GlobalVar.playerHP -= 10;
            Destroy(bug.gameObject);
        }
        if (collision.gameObject.CompareTag("player"))
        {
            if (!pointStop)
            {
                pointStop = true;
                GlobalVar.gamePoint += 10;
            }
            negate = true;
            StartCoroutine(DelayDestroy());
        }
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(bug.gameObject);
    }
}
