using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Root : MonoBehaviour
{
    static Dictionary<Type, UnityEngine.Object[]> dic = new Dictionary<Type, UnityEngine.Object[]>();

    GameObject popupRoot;
    GameObject sceneRoot;

    void Start()
    {
        popupRoot = new GameObject { name = "Popup_Root" };
        sceneRoot = new GameObject { name = "Scene_Root" };
        popupRoot.transform.parent = transform;
        sceneRoot.transform.parent = transform;
        LoadAllUI();
    }

    void LoadAllUI()
    {
        InstantiateUI(typeof(Define.UI_Popup), popupRoot.transform);
        InstantiateUI(typeof(Define.UI_Scene), sceneRoot.transform);
    }

    void InstantiateUI(Type type, Transform parent)
    {
        string[] strs = Enum.GetNames(type);
        dic[type] = new UnityEngine.Object[strs.Length];
        for (int i = 0; i < strs.Length; i++)
        {
            UnityEngine.Object obj = Resources.Load($"Prefabs/UI/{type.Name}/{strs[i]}");
            if (obj == null)
            {
                Debug.Log($"{strs[i]} popup prefab is not exist");
                continue;
            }
            dic[type][i] = Instantiate(obj, parent);
            dic[type][i].name = strs[i];
        }
    }

    public static GameObject GetUI(Type type, int idx)
    {
        return dic[type][idx] as GameObject;
    }
}
