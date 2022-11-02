using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    [SerializeField]
    IngredientMenu menu;
    [SerializeField]
    CookPuzzle cookPuzzle;
    public int order = 0;
    public void Cook(GameObject go)
    {
        menu.Delete(go.name);
        order++;
        if (order == 2)
            menu.Insert("ButterBread");
        else if (order == 5)
            cookPuzzle.Clear();
    }
}
