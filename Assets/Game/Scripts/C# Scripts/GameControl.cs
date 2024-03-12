using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private GameObject Movingelements;
    private GameObject Camera;
    private Death deathscript;
    private Jump jump;
    private Camera_Control camcontrol;
    private Movingelements movingscript;
    private float originecamera;
    private bool antiloop = false;

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
        Movingelements = GameObject.FindGameObjectWithTag("MovingElements");
        movingscript = Movingelements.GetComponent<Movingelements>();
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
        movingscript.speed = Game_speed;

        if (Game_Reset)
        {
            if (!antiloop)
            {
                movingscript.dowereset = true;
                antiloop = true;
            }

            if (!movingscript.dowereset)
            {
                gameObject.transform.position = new Vector3(0, 1, deathscript.Posref);
                Camera.transform.position = new Vector3(Camera.transform.position.x, originecamera, Camera.transform.position.z);
                deathscript.dead = false;
                Game_Reset = false;
                movingscript.canmove = true;
                antiloop = false;
            }
        }
    }
}
