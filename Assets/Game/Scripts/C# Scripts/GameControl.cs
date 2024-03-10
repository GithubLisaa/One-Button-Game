using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private GameObject[] movingcubes;
    private GameObject[] movingspikes;
    private GameObject Camera;
    private Death deathscript;
    private Jump jump;
    private Camera_Control camcontrol;
    private float originecamera;

    public float Game_speed = 1f;
    public float Gravity = 1f;
    public float Jump_force = 1f;
    public float Death_cube_collid_error = 1f;
    public float Camera_player_max_high = 1f;
    public float Camera_player_max_low = 1f;
    public bool Game_Reset = false;

    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        originecamera = Camera.transform.position.y;
        camcontrol = Camera.GetComponent<Camera_Control>();
        movingcubes = GameObject.FindGameObjectsWithTag("MovingCube");
        movingspikes = GameObject.FindGameObjectsWithTag("MovingSpike");
        deathscript = gameObject.GetComponent<Death>();
        jump = gameObject.GetComponent<Jump>();
    }

    void Update()
    {
        jump.jumpforce = Jump_force;
        Physics.gravity = new Vector3(0, -Gravity, 0);
        camcontrol.MaxHigh = Camera_player_max_high;
        camcontrol.MaxLow = Camera_player_max_low;
        deathscript.erreurmax = Death_cube_collid_error;
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
            Camera.transform.position = new Vector3(Camera.transform.position.x, originecamera, Camera.transform.position.z);
            deathscript.dead = false;
            Game_Reset = false;
        }
    }
}
