using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonOrbit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject moon;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(-0.5f, -0.5f, 0.0f);
    }
}
