using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public GameObject bulbPuzzle;

    public void ResetAllBulb()
    {
        bulbPuzzle.GetComponent<BulbPuzzle_4x4>().SetoffAllBulb();
    }
}
