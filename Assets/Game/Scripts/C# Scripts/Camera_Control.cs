using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    private GameObject player;
    private float camypos = 0f;
    private float playpos = 0f;

    public float MaxHigh = 0f;
    public float MaxLow = 0f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        camypos = gameObject.transform.position.y;
        playpos = player.transform.position.y;

        if (playpos > camypos + MaxHigh)
        {
            transform.position = new Vector3(transform.position.x, playpos - MaxHigh, transform.position.z);
        }
        else if (playpos < camypos - MaxLow)
        {
            transform.position = new Vector3(transform.position.x, playpos + MaxLow, transform.position.z);
        }
    }
}
