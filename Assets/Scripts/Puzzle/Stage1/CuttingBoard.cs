using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuttingBoard : MonoBehaviour
{
    [SerializeField]
    Sprite[] ingredientImage;
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
    [SerializeField]
    float waitingTime;
    int sortingOrder = 4;
    public void Cook(GameObject go)
    {
        PutIngredient(go.name, order);
        menu.Delete(go.name);
        order++;
        if (order == 2)
        {
            DeleteAllIngredient();
            PutIngredient("ButterBread", 2);
            StartCoroutine(MainCook("ButterBread"));
            order++;
        }
        else if (order == 6)
        {
            PutIngredient("CookedBread2", 3);
            cookPuzzle.Clear();
            DeleteAllIngredient();
        }
    }

    IEnumerator MainCook(string name)
    {
        yield return new WaitForSeconds(waitingTime);
        menu.Insert(name);
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

    public void DeleteAllIngredient()
    {
        foreach (GameObject ingredient in ingredients)
            Destroy(ingredient);
        ingredients.Clear();
    }
}
