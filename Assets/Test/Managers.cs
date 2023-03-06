using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers instance;
    public static Managers Instance { get { Init(); return instance; } }

    public InfoUIManager infoUIManager;

    // UIManager _UI = new UIManager();
    // public static UIManager UI { get { return Instance._UI;}}

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    static void Init()
    {
        GameObject go = GameObject.Find("@Managers");
        if(go == null)
        {
            go = new GameObject { name = "@Managers" };
        }

        if (go.GetComponent<Managers>() == null)
        {
            go.AddComponent<Managers>();
        }

        DontDestroyOnLoad(go);
        instance = go.GetComponent<Managers>();
    }
}
