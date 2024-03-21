using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingelements : MonoBehaviour
{
    public bool canmove = true;
    public float speed = 1f;
    public bool dowereset = false;

    private Vector3 transformorigin;

    void Start()
    {
        transformorigin = transform.position;
    }

    void Update()
    {
        if (canmove)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            if (dowereset)
            {
                transform.position = transformorigin;
                dowereset = false;
            }
        }
        else if (dowereset)
        {
            transform.position = transformorigin;
            dowereset = false;
        }
    }
}
