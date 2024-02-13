using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class LensCameraRotation : MonoBehaviour
{
    public Camera mainCamera;

    void Update()
    {
        if (mainCamera is not null)
        {
            // Calculate vector from magnifying glass camera to main camera
            var lensTransform = transform;
            Vector3 toMainCamera = mainCamera.transform.position - lensTransform.position;
            

            // Calculate the relative rotation based on the direction to the main camera
            Quaternion relativeRotation = Quaternion.LookRotation(-toMainCamera, lensTransform.up);
            lensTransform.rotation = relativeRotation;
        }
    }
}