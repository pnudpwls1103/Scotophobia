using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager
{
    // keyboard input 관리
    public Action KeyAction = null;

    public void OnUpdate()
    {
        if (Input.anyKey == false)
            return;
        
        if (KeyAction != null)
            KeyAction.Invoke();
    }
}
