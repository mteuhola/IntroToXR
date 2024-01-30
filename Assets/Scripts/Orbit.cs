using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject planet;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, 0.5f, 0.0f);
    }
}
