using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private GameObject[] movingcubes;
    private GameObject[] movingspikes;
    private Death deathscript;
    private Jump jump;

    public float Game_speed = 1f;
    public float Jump_force = 1f;
    public bool Game_Reset = false;

    void Start()
    {
        movingcubes = GameObject.FindGameObjectsWithTag("MovingCube");
        movingspikes = GameObject.FindGameObjectsWithTag("MovingSpike");
        deathscript = gameObject.GetComponent<Death>();
        jump = gameObject.GetComponent<Jump>();
    }

    void Update()
    {
        jump.jumpforce = Jump_force;
        foreach (GameObject cube in movingcubes)
        {
            Movingelements scriptMoving = cube.GetComponent<Movingelements>();
            scriptMoving.speed = Game_speed;
        }

        foreach (GameObject spike in movingspikes)
        {
            Movingelements scriptMoving = spike.GetComponent<Movingelements>();
            scriptMoving.speed = Game_speed;
        }

        if (Game_Reset)
        {
            foreach (GameObject cube in movingcubes)
            {
                Movingelements scriptMoving = cube.GetComponent<Movingelements>();
                scriptMoving.dowereset = true;
            }

            foreach (GameObject spike in movingspikes)
            {
                Movingelements scriptMoving = spike.GetComponent<Movingelements>();
                scriptMoving.dowereset = true;
            }
            gameObject.transform.position = new Vector3 (0, 1, deathscript.Posref);
            deathscript.Showdeathscreen = false;
            Game_Reset = false;
        }
    }
}
