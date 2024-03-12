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
            rbody.AddForce(new Vector3(0, Bumperforce, 0), ForceMode.Impulse);
        }
    }
}
