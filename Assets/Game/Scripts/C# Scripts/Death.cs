using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Death : MonoBehaviour
{
    private GameObject[] movingcubes;
    private GameObject[] movingspikes;
    private GameObject[] deathscreen;

    public bool dead = false;
    public float Posref = 0f;
    public float erreurmax = 0f;

    void Start()
    {
        movingcubes = GameObject.FindGameObjectsWithTag("MovingCube");
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
            foreach (GameObject cube in movingcubes)
            {
                Movingelements scriptMoving = cube.GetComponent<Movingelements>();
                scriptMoving.canmove = false;
            }
            foreach (GameObject spike in movingspikes)
            {
                Movingelements scriptMoving = spike.GetComponent<Movingelements>();
                scriptMoving.canmove = false;
            }
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
            foreach (GameObject cube in movingcubes)
            {
                Movingelements scriptMoving = cube.GetComponent<Movingelements>();
                scriptMoving.canmove = false;
            }

            foreach (GameObject spike in movingspikes)
            {
                Movingelements scriptMoving = spike.GetComponent<Movingelements>();
                scriptMoving.canmove = false;
            }
            dead = true;
        }
    }
}
