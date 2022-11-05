using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleManager : MonoBehaviour
{
    public delegate void Callback();
    public Callback checkManager = null;

    public void SetCheckManager(Callback call)
    {
        checkManager += call;
    }

}
