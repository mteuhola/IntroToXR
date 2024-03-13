using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomFollow : MonoBehaviour
{
    public GameObject followObject;
    public float followSpeed = 30f;
    public float rotateSpeed = 100f;
    private Transform _followTarget;
    private Rigidbody _body;

    // Start is called before the first frame update
    void Start()
    {
        _followTarget = followObject.transform;
        _body = GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;
        _body.mass = 20f;

        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        PhysicsMove();
    }

    private void PhysicsMove()
    {
        //Position
        var distance = Vector3.Distance(_followTarget.position, transform.position);
        _body.velocity = (_followTarget.position - transform.position).normalized * (followSpeed * distance);

        //Rotation
        var q = _followTarget.rotation * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
    }
}