using UnityEngine;
using UnityEngine.InputSystem;

public class Breakout : MonoBehaviour
{
    public InputActionReference action;

    public Vector3 startPosition = new Vector3(0f, 0f, 0f);
    public Vector3 targetPosition = new Vector3(10f, 0f, 0f);

    void Start()
    {
        MoveToStart();
        action.action.Enable();
    }

    void Update()
    {
        action.action.performed += (ctx) =>
        {
            float distS = Vector3.Distance(transform.position, startPosition);
            float distT = Vector3.Distance(transform.position, targetPosition);
            if (distS < distT)
            {
                MoveToTarget();
            }
            else
            {
               MoveToStart();
            }
        };
    }

    void MoveToStart()
    {
        transform.position = startPosition;
    }

    void MoveToTarget()
    {
        transform.position = targetPosition;
    }
}