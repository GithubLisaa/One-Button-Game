using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private GameObject[] movingcubes;
    private GameObject[] movingspikes;

    public bool canmove = true;
    public float speed = 1f;

    void Start()
    {
        movingcubes = GameObject.FindGameObjectsWithTag("MovingCube");
        movingspikes = GameObject.FindGameObjectsWithTag("MovingSpike");
    }

    void Update()
    {
        if (canmove)
        {
            foreach (GameObject element in movingcubes)
            {
                element.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }

            foreach (GameObject element in movingspikes)
            {
                element.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
    }
}
