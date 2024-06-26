using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private GameObject Camera;
    private GameObject Movingelements;
    private Movingelements movingscript;

    public bool dead = false;
    public float Posref = 0f;
    public float erreurmax = 0f;

    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Movingelements = GameObject.FindGameObjectWithTag("MovingElements");
        movingscript = Movingelements.GetComponent<Movingelements>();
        dead = false;
    }
    void Update()
    {
        if (dead)
        {
            Camera.GetComponent<AudioSource>().Stop();
            movingscript.canmove = false;
        }

        if (Mathf.Abs(transform.position.z - Posref) > erreurmax)
        {
            dead = true;
        }
    }
    void OnTriggerEnter(Collider spikes)
    {
        if (spikes.gameObject.CompareTag("MovingSpike"))
        {
            movingscript.canmove = false;
            dead = true;
        }
    }
}
