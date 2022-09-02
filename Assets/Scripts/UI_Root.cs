using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Root : MonoBehaviour
{
    static Dictionary<Type, (UnityEngine.Object, bool)[]> dic = new Dictionary<Type, (UnityEngine.Object, bool)[]>();

    GameObject popupRoot;
    GameObject sceneRoot;

    void Start()
    {
        popupRoot = new GameObject { name = "Popup_Root" };
        sceneRoot = new GameObject { name = "Scene_Root" };
        popupRoot.transform.parent = transform;
        sceneRoot.transform.parent = transform;
        LoadAllUI();
        InitUI();
    }

    void LoadAllUI()
    {
        InstantiateUI(typeof(Define.UI_Popup), popupRoot.transform);
        InstantiateUI(typeof(Define.UI_Scene), sceneRoot.transform);
    }

    void InstantiateUI(Type type, Transform parent)
    {
        string[] strs = Enum.GetNames(type);
        dic[type] = new (UnityEngine.Object, bool)[strs.Length];
        for (int i = 0; i < strs.Length; i++)
        {
            UnityEngine.Object obj = Resources.Load($"Prefabs/UI/{type.Name}/{strs[i]}");
            if (obj == null)
            {
                Debug.Log($"{strs[i]} ui prefab is not exist");
                continue;
            }
            dic[type][i].Item1 = Instantiate(obj, parent);
            dic[type][i].Item1.name = strs[i];
        }
    }

    void InitUI()
    {
        for (int i = 0; i < dic[typeof(Define.UI_Popup)].Length; i++)
        {
            GameObject go = dic[typeof(Define.UI_Popup)][i].Item1 as GameObject;
            go.SetActive(false);
            dic[typeof(Define.UI_Popup)][i].Item2 = false;
        }
        for (int i = 0; i < dic[typeof(Define.UI_Scene)].Length; i++)
        {
            GameObject go = dic[typeof(Define.UI_Scene)][i].Item1 as GameObject;
            Canvas canvas = go.GetComponent<Canvas>();
            if (canvas == null)
            {
                Debug.Log($"{go.name} : need Canvas component");
                continue;
            }
            canvas.sortingOrder = 0;
            dic[typeof(Define.UI_Popup)][i].Item2 = true;
        }
    }

    public static void TogglePopup(Type type, int idx)
    {
        if (type.Name != "UI_Popup")
            return;
        GameObject go = dic[type][idx].Item1 as GameObject;
        go.SetActive(!dic[type][idx].Item2);
        dic[type][idx].Item2 = !dic[type][idx].Item2;
    }

    public static GameObject GetUI(Type type, int idx)
    {
        return dic[type][idx].Item1 as GameObject;
    }
}
