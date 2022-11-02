using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    public int order = 0;
    [SerializeField]
    IngredientMenu menu;
    public void Cook(GameObject go)
    {
        menu.Delete(go.name);
        order++;
        if (order == 1)
            menu.Insert("CookedBread");
        else if (order == 2)
            menu.Insert("CookedEgg");
    }
}
