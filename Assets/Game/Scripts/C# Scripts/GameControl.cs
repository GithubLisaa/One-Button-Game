using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private GameObject[] Fakeblocks;
    private GameObject[] FallingPlatforms;
    private GameObject Movingelements;
    private GameObject Camera;
    private Death deathscript;
    private Jump jump;
    private Camera_Control camcontrol;
    private Movingelements movingscript;
    private Boosters boosterscript;
    private float originecamera;
    private bool antiloop = false;

    [HideInInspector]
    public float gamespeedorigin = 1f;

    public float Game_speed = 1f;
    public float Gravity = 1f;
    public float Jump_force = 1f;
    public float Death_cube_collid_error = 1f;
    public float Camera_player_max_high = 1f;
    public float Camera_player_max_low = 1f;
    public float Bumper_force = 1f;
    public float Speed_Boost = 1f;
    public float Crumble_Shake = 1f;
    public float Platform_Timer = 1f;
    public bool Game_Reset = false;

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Fakeblocks = GameObject.FindGameObjectsWithTag("Fake_Block");
        FallingPlatforms = GameObject.FindGameObjectsWithTag("Falling_Platform");
        originecamera = Camera.transform.position.y;
        camcontrol = Camera.GetComponent<Camera_Control>();
        Movingelements = GameObject.FindGameObjectWithTag("MovingElements");
        movingscript = Movingelements.GetComponent<Movingelements>();
        deathscript = gameObject.GetComponent<Death>();
        jump = gameObject.GetComponent<Jump>();
        boosterscript = gameObject.GetComponent<Boosters>();
        gamespeedorigin = Game_speed;
        foreach (GameObject platforms in FallingPlatforms)
        {
            FallingPlatform platformscript = platforms.GetComponent<FallingPlatform>();
            platformscript.strengh_shake = Crumble_Shake;
            platformscript.platformtimer = Platform_Timer;
        }
    }

    void Update()
    {
        jump.jumpforce = Jump_force;
        boosterscript.Bumperforce = Bumper_force;
        Physics.gravity = new Vector3(0, -Gravity, 0);
        camcontrol.MaxHigh = Camera_player_max_high;
        camcontrol.MaxLow = Camera_player_max_low;
        deathscript.erreurmax = Death_cube_collid_error;
        movingscript.speed = Game_speed;
        if (deathscript.dead)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (Game_Reset)
        {
            if (!antiloop)
            {
                Game_speed = gamespeedorigin;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                movingscript.dowereset = true;
                antiloop = true;
            }

            if (!movingscript.dowereset)
            {
                Gravity = Mathf.Abs(Gravity);
                gameObject.transform.position = new Vector3(0, 1, deathscript.Posref);
                Camera.transform.position = new Vector3(Camera.transform.position.x, originecamera, Camera.transform.position.z);
                deathscript.dead = false;
                Game_Reset = false;
                movingscript.canmove = true;
                antiloop = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                foreach (GameObject platforms in FallingPlatforms)
                {
                    FallingPlatform platformscript = platforms.GetComponent<FallingPlatform>();
                    platformscript.strengh_shake = Crumble_Shake;
                    platformscript.platformtimer = Platform_Timer;
                    platformscript.dead = true;
                }
                foreach (GameObject fakeblock in Fakeblocks)
                {
                    Fakeblock scriptfakeblock = fakeblock.GetComponent<Fakeblock>();
                    scriptfakeblock.meshstatue = true;
                }
            }
        }
    }
}
