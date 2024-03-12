using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Death : MonoBehaviour
{
    private GameObject[] movingspikes;
    private GameObject[] deathscreen;
    private GameObject Movingelements;
    private Movingelements movingscript;

    public bool dead = false;
    public float Posref = 0f;
    public float erreurmax = 0f;

    void Start()
    {
        Movingelements = GameObject.FindGameObjectWithTag("MovingElements");
        movingscript = Movingelements.GetComponent<Movingelements>();
        movingspikes = GameObject.FindGameObjectsWithTag("MovingSpike");
        deathscreen = GameObject.FindGameObjectsWithTag("DeathScreen");
        dead = false;
    }
    void Update()
    {
        if (dead)
        {
            foreach (GameObject Deathscreen in deathscreen)
            {
                MeshRenderer mesh = Deathscreen.GetComponent<MeshRenderer>();
                mesh.enabled = true;
            }
            movingscript.canmove = false;
        }
        else
        {
            foreach (GameObject Deathscreen in deathscreen)
            {
                MeshRenderer mesh = Deathscreen.GetComponent<MeshRenderer>();
                mesh.enabled = false;
            }
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
