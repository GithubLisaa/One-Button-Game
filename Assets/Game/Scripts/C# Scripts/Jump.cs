using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody rbody;
    private Death deathscript;
    private GameControl gamecontrolscript;
    private bool onfloor = true;
    private bool isjumping = false;

    public float jumpforce= 1f;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        deathscript = gameObject.GetComponent<Death>();
        gamecontrolscript = GetComponent<GameControl>();
    }

    void Update()
    {
        if (Mathf.Abs(rbody.velocity.y) > 0.01f)
        {
            onfloor = false;
        }
        else
        {
            onfloor = true;
        }

        if (Input.anyKey && onfloor && !isjumping && !deathscript.dead)
        {
            gameObject.transform.position = new Vector3(0, transform.position.y, 0);
            if (gamecontrolscript.Gravity>0)
            {
                rbody.AddForce(new Vector3(0, jumpforce, 0), ForceMode.Impulse);
            }
            else
            {
                rbody.AddForce(new Vector3(0, -jumpforce, 0), ForceMode.Impulse);
            }
            onfloor = false;
            isjumping = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MovingCube" || collision.gameObject.tag == "Floor")
        {
            isjumping = false;
        }
    }
}
