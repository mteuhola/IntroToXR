using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPress : MonoBehaviour
{
    public Light light;

    public Color purple = new Color(255,0,255);

    void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hand")
        {
           light.color = purple; 
        }

    }
}
