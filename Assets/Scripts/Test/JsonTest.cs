using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Test
{
    public int id;
    public string name;
    public string text;
}


public class JsonTest : MonoBehaviour
{
    public TextAsset JsonFile;
    public Dictionary<int, Test> testList = new Dictionary<int, Test>();
    
    void Start()
    {
        var arrData = JsonConvert.DeserializeObject<Test[]>(JsonFile.text);
        foreach(var data in arrData)
        {
            Debug.Log($"{data.id}, {data.name}, {data.text}");
        }
        
    }
}
