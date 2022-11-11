using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FryingPan : MonoBehaviour
{
    public int order = 0;
    [SerializeField]
    IngredientMenu menu;

    List<GameObject> ingredients = new List<GameObject>();
    [SerializeField]
    Vector2 ingredientPos;
    [SerializeField]
    float size;
    [SerializeField]
    float watingTime;
    int sortingOrder = 4;
    public void Cook(GameObject go)
    {
        PutIngredient(go);
        menu.Delete(go.name);
        order++;
        if (order == 1)
            StartCoroutine(MainCook("CookedBread"));
        else if (order == 2)
            StartCoroutine(MainCook("CookedEgg"));
    }

    

    IEnumerator MainCook(string name)
    {
        yield return new WaitForSeconds(watingTime);
        menu.Insert(name);
        DeleteAllIngredient();
    }

    void PutIngredient(GameObject go)
    {
        GameObject ingredient = new GameObject();
        ingredient.transform.position = ingredientPos;
        ingredient.transform.localScale = new Vector3(1, 1, 1) * size;
        ingredient.name = go.name;
        SpriteRenderer sr = ingredient.AddComponent<SpriteRenderer>();
        sr.sprite = go.GetComponent<Image>().sprite;
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
