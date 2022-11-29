using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Door[] doors;
    public void SetActivate()
    {
        int stage = GameManager.Instance.LimitStage;
        foreach (Door door in doors)
        {
            door.IsActivate = (stage == door.id) ? true : false;
        }
    }
}
