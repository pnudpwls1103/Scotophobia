using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : UI_Base
{
    static Inventory instance = null;
    public static Inventory Instance { get { return instance; } }
    Dictionary<string, GameObject> items = new Dictionary<string, GameObject>();
    enum GameObjects
    {
        Panel,
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        Bind(typeof(GameObjects));
    }

    public void Insert(string str)
    {
        GameObject go = Resources.Load<GameObject>($"Prefabs/UI/UI_Popup/{str}");
        if (go == null)
        {
            Debug.Log($"Item Prefab named {str} is not exist. Make GameObject's name equal Prefab's name");
            return;
        }
        items[str] = Instantiate<GameObject>(go);
        if (items[str] == null)
        {
            Debug.Log($"{str} Instantiate fail");
            return;
        }
        items[str].transform.SetParent((dic[typeof(GameObjects)][(int)GameObjects.Panel] as GameObject).transform);
    }

    public void Delete(string str)
    {
        if (!isExist(str))
            return;
        Destroy(items[str]);
        items.Remove(str);
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
