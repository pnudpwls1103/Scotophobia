using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> dic = new Dictionary<Type, UnityEngine.Object[]>();

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] strs = Enum.GetNames(type);
        dic[type] = new UnityEngine.Object[strs.Length];
        for (int i = 0; i < strs.Length; i++)
            foreach (T com in GetComponentsInChildren<T>())
                if (com.name == strs[i])
                    dic[type][i] = com;
    }
}
