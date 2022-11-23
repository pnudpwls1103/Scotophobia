using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUnLoad : MonoBehaviour
{
    public string objName;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject obj = GameObject.Find(objName);
            PuzzleTrigger trigger = obj.GetComponent<PuzzleTrigger>();
            trigger.Restore();
        }       
    }
}
