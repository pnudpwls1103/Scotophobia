using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuttingBoard : MonoBehaviour
{
    [SerializeField]
    IngredientMenu menu;
    [SerializeField]
    CookPuzzle cookPuzzle;
    public int order = 0;

    List<GameObject> ingredients = new List<GameObject>();
    [SerializeField]
    Vector2 ingredientPos;
    [SerializeField]
    float size;
    int sortingOrder = 4;
    public void Cook(GameObject go)
    {
        PutIngredient(go);
        menu.Delete(go.name);
        order++;
        if (order == 2)
        {
            menu.Insert("ButterBread");
            DeleteAllIngredient();
        }
        else if (order == 5)
        {
            cookPuzzle.Clear();
            DeleteAllIngredient();
        }
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
