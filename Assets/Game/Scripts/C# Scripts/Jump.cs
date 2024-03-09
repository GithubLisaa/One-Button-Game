using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody body;
    private bool onfloor = true;
    private bool isjumping = false;

    public float jumpforce= 1f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Mathf.Abs(body.velocity.y) > 0.01f)
        {
            onfloor = false;
        }
        else
        {
            onfloor = true;
        }

        if (Input.anyKey && onfloor && !isjumping)
        {
            body.AddForce(new Vector3(0, jumpforce, 0), ForceMode.Impulse);
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