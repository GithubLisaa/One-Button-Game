using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFace : MonoBehaviour
{
    private GameControl controlscript;

    void Start()
    {
        controlscript = gameObject.GetComponentInParent<GameControl>();
    }


    void Update()
    {
        if (controlscript.Gravity > 0)
        {
            transform.rotation = Quaternion.Euler(90f, 0f, 90f);
        }
        if (controlscript.Gravity < 0)
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, 90f);
        }
    }
}
