using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private GameObject[] movingcubes;
    private GameObject[] movingspikes;
    private GameObject deathscreen;

    public float Posref = 0f;
    public bool Showdeathscreen = false;

    void Start()
    {
        movingcubes = GameObject.FindGameObjectsWithTag("MovingCube");
        movingspikes = GameObject.FindGameObjectsWithTag("MovingSpike");
        deathscreen = GameObject.FindGameObjectWithTag("DeathScreen");
        Showdeathscreen = false;
    }
    void Update()
    {
        if (Showdeathscreen)
        {
            deathscreen.SetActive(true);
        }
        else
        {
            deathscreen.SetActive(false);
        }

        foreach (GameObject cube in movingcubes)
        {
            Movingelements scriptMoving = cube.GetComponent<Movingelements>();
            if (transform.position.z != Posref)
            {
                scriptMoving.canmove = false;
            }
        }

        foreach (GameObject spike in movingspikes)
        {
            Movingelements scriptMoving = spike.GetComponent<Movingelements>();
            if (transform.position.z != Posref)
            {
                scriptMoving.canmove = false;
            }
        }

        if (transform.position.z != Posref)
        {
            Showdeathscreen = true;
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
            Showdeathscreen = true;
        }
    }
}
