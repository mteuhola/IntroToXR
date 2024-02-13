using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensController : MonoBehaviour
{
    public Transform lens, mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localPlayer = lens.InverseTransformPoint(mainCamera.position);

        Vector3 lookAtMirror = lens.TransformPoint(new Vector3(-localPlayer.x, -localPlayer.y, -localPlayer.z));
        transform.LookAt(lookAtMirror, lens.up);
    }
}
