using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : ObjectData, IInteraction
{
    public bool isActivate = true;
    public bool IsActivate
    {
        get
        {
            return isActivate;
        }
        set
        {
            isActivate = value;
        }
    }

    public abstract void Interact(GameObject gameObject);
    public abstract void Action(GameObject gameObject);
}
