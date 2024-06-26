using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosters : MonoBehaviour
{
    private GameControl gamecontrolscript;
    private Rigidbody rbody;
    private Death deathscript;

    public float Bumperforce = 1f;
    void Start()
    {
        gamecontrolscript = GetComponent<GameControl>();
        deathscript = gameObject.GetComponent<Death>();
        rbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider element)
    {
        if (element.gameObject.tag == "Invert_Gravity_Portal" && !deathscript.dead)
        {
            gamecontrolscript.Gravity = -gamecontrolscript.Gravity;
        }

        if (element.gameObject.tag == "Reset_Gravity_Portal" && !deathscript.dead)
        {
            gamecontrolscript.Gravity = Mathf.Abs(gamecontrolscript.Gravity);
        }

        if (element.gameObject.tag == "Bumper" && !deathscript.dead)
        {
            if (gamecontrolscript.Gravity > 0)
            {
                rbody.velocity = Vector3.zero;
                rbody.AddForce(new Vector3(0, Bumperforce, 0), ForceMode.Impulse);
            }
            else
            {
                rbody.velocity = Vector3.zero;
                rbody.AddForce(new Vector3(0, -Bumperforce, 0), ForceMode.Impulse);
            }
        }
        if (element.gameObject.tag == "Speed_Boost" && !deathscript.dead)
        {
            gamecontrolscript.Game_speed = gamecontrolscript.Game_speed + gamecontrolscript.Speed_Boost;
        }
        if (element.gameObject.tag == "Speed_Reset" && !deathscript.dead)
        {
            gamecontrolscript.Game_speed = gamecontrolscript.gamespeedorigin;
        }
        if (element.gameObject.tag == "sphere_bumper" && !deathscript.dead)
        {
            Debug.Log("BAAAWWW");
            if (Input.anyKey && !deathscript.dead)
            {
                if (gamecontrolscript.Gravity > 0)
                {
                    Debug.Log("E");
                    rbody.velocity = Vector3.zero;
                }
                else
                {
                    rbody.velocity = Vector3.zero;
                }
            }
        }
    }
}
