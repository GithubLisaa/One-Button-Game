using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fakeblock : MonoBehaviour
{
    private GameObject Player;
    private Death deathscript;
    private MeshRenderer meshRenderer;

    public bool meshstatue = true;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        deathscript = Player.GetComponent<Death>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        meshRenderer.enabled = meshstatue;
    }
    void OnTriggerEnter(Collider element)
    {
        if (element.gameObject.CompareTag("Player") || element.gameObject.CompareTag("Falling_Platform") && !deathscript.dead)
        {
            gameObject.GetComponent<ParticleSystem>().Play();
            meshstatue = false;
        }
    }
}
