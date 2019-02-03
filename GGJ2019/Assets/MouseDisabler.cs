using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDisabler : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
