using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientMenu : UI_Base
{
    Dictionary<string, GameObject> items = new Dictionary<string, GameObject>();
    enum GameObjects
    {
        Panel,
    }
    private void Start()
    {
        Bind(typeof(GameObjects));
        Insert("Bread");
        Insert("Ham");
        Insert("Egg");
        Insert("Butter");
        
        
    }

    public void Insert(string str)
    {
        GameObject go = Resources.Load<GameObject>($"Prefabs/UI/UI_Scene/Ingredients/{str}");
        if (go == null)
        {
            Debug.Log($"Item Prefab named {str} is not exist. Make GameObject's name equal Prefab's name");
            return;
        }
        items[str] = Instantiate<GameObject>(go);
        items[str].name = str;
        if (items[str] == null)
        {
            Debug.Log($"{str} Instantiate fail");
            return;
        }
        items[str].transform.SetParent((dic[typeof(GameObjects)][(int)GameObjects.Panel] as GameObject).transform);
    }

    public bool Delete(string str)
    {
        if (!isExist(str))
            return false;
        Destroy(items[str]);
        items.Remove(str);
        return true;
    }

    public GameObject GetItem(string str)
    {
        if (!isExist(str))
            return null;
        return items[str];
    }

    public bool isExist(string str)
    {
        return items.ContainsKey(str);
    }
}
