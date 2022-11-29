using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FryingPan : MonoBehaviour
{
    [SerializeField]
    Sprite[] ingredientImage;
    [SerializeField]
    GameObject eggSmoke;
    [SerializeField]
    IngredientMenu menu;
    public int order = 0;

    List<GameObject> ingredients = new List<GameObject>();
    [SerializeField]
    Vector2 ingredientPos;
    [SerializeField]
    float size;
    [SerializeField]
    float waitingTime;
    int sortingOrder = 4;
    public void Cook(GameObject go)
    {
        PutIngredient(go.name, order);
        menu.Delete(go.name);
        order++;
        if (order == 1)
        {
            StartCoroutine(MainCook("CookedBread", true));
        }
            
        else if (order == 2)
        {
            DeleteAllIngredient();
            PutIngredient("FriedEgg", 3);
            StartCoroutine(MainCook("CookedEgg", true));
        }
            
    }

    IEnumerator MainCook(string name, bool isInsert)
    {
        if(name == "CookedEgg")
            eggSmoke.SetActive(true);
        yield return new WaitForSeconds(waitingTime);
        if(isInsert)
            menu.Insert(name);
        eggSmoke.SetActive(false);
        DeleteAllIngredient();
    }

    void PutIngredient(string name, int imageIdx)
    {
        GameObject ingredient = new GameObject();
        ingredient.transform.position = ingredientPos;
        ingredient.transform.localScale = new Vector3(1, 1, 1) * size;
        ingredient.name = name;
        SpriteRenderer sr = ingredient.AddComponent<SpriteRenderer>();
        sr.sprite = ingredientImage[imageIdx];
        sr.sortingOrder = sortingOrder;
        sortingOrder++;
        ingredients.Add(ingredient);
    }

    void DeleteAllIngredient()
    {
        foreach (GameObject ingredient in ingredients)
            Destroy(ingredient);
        ingredients.Clear();
    }
}
