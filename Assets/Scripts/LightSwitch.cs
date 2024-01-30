using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public InputActionReference action;

    public Light light;

    public Color red = new Color(255,0,0);
    public Color green = new Color(0,255,0);
    public Color blue = new Color(0,0,255);
    public Color white = new Color(255,255,255);
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        action.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        action.action.performed += (ctx) =>
        {
            CycleLights();
        };
    }

    void CycleLights()
    {
        if (light.color == white)
            {
                light.color = red;
            }
            else if (light.color == red)
            {
                light.color = green;
            }
            else if (light.color == green)
            {
                light.color = blue;
            }
            else
            {
                light.color = white;
            }
    }
}
