using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LICOOOOOOOOOOOOOOOOOOOOOOOOOOOOORN : MonoBehaviour
{
    public int time = 2;
    private Material materialcolor;

    void Start()
    {
        materialcolor = gameObject.GetComponent<Renderer>().material;
    }

    void Update()
    {
        materialcolor.color = Color.red;
        StartCoroutine(wait());
        materialcolor.color = Color.blue;
        StartCoroutine(wait());
        materialcolor.color = Color.green;
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(time);
    }
}
