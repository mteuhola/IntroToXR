using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomGrab : MonoBehaviour
{
    CustomGrab otherHand = null;
    public List<Transform> nearObjects = new List<Transform>();
    public Transform grabbedObject = null;
    public InputActionReference action;
    bool grabbing = false;

    private Vector3 previousPosition;
    private Quaternion previousRotation;

    private void Start()
    {
        action.action.Enable();

        // Find the other hand
        foreach (CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }
    }

    void Update()
    {
        grabbing = action.action.IsPressed();

        if (grabbing)
        {
            // Grab nearby object or the object in the other hand
            if (!grabbedObject)
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;

            if (grabbedObject)
            {
                //First track the deltas of pos/rot
                Vector3 deltaPosition = transform.position - previousPosition;
                Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(previousRotation);

                //For position, addition is sufficient
                grabbedObject.position += deltaPosition;

                //Calculate new rotation based on current rotation and the delta rotation
                Quaternion newRotation = deltaRotation * grabbedObject.rotation;
                grabbedObject.rotation = newRotation;


                //Update values
                previousPosition = transform.position;
                previousRotation = transform.rotation;

                // Get the rigidbody component of the grabbed object (to later disable its gravity when grabbed)
                Rigidbody rigid = grabbedObject.GetComponent<Rigidbody>();
                rigid.useGravity = false;
                rigid.velocity = Vector3.zero;
                rigid.angularVelocity = Vector3.zero;
            }
        }
        // If let go of button, release object
        else if (grabbedObject)
        {
            // Get the rigidbody component of the grabbed object
            Rigidbody rigid = grabbedObject.GetComponent<Rigidbody>();
            // Re-enable object's gravity
            rigid.useGravity = true;
            grabbedObject = null;
        }
            
        // Should save the current position and rotation here
        previousPosition = transform.position;
        previousRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform t = other.transform;
        if (t && t.tag.ToLower() == "grabbable")
            nearObjects.Add(t);
    }

    private void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        if (t && t.tag.ToLower() == "grabbable")
            nearObjects.Remove(t);
    }
}