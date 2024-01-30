using UnityEngine.InputSystem;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public InputActionReference action;

    void Start()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        };
    }
}