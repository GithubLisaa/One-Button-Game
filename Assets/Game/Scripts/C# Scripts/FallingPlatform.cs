using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Death deathscript;
    private bool crumble = false;
    private Vector3 posorigine;

    public float strengh_shake = 1f;
    public float platformtimer = 1f;
    public bool dead = false;

    void Start()
    {
        deathscript = GameObject.FindGameObjectWithTag("Player").GetComponent<Death>();
        posorigine = transform.position;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
        if (crumble && !dead)
        {
            transform.position = new Vector3(posorigine.x + Random.Range(strengh_shake, -strengh_shake), transform.position.y, transform.position.z);
        }
        else if (dead)
        {
            crumble = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.position = new Vector3(posorigine.x, posorigine.y, transform.position.z);
            dead = false;
        }
        dead = deathscript.dead;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            crumble = true;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(platformtimer);
        if (crumble)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
