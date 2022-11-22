using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{    
    Queue<LineData> lineQueue;
    List<LineData> lineList;
    public int lineIndex = 0;
    void GenerateData()
    {
        lineList.Add(new LineData(1, "???", new string[]{"아이야, 나아가야 해"}));
        lineList.Add(new LineData(1, "아이", new string[]{"(아빠가 일어나기 전에 아침밥을 차려야 해.)", "(우리 아빠는 너무 상냥해)"}));
    }

    void Awake()
    {
        lineQueue = new Queue<LineData>();
        lineList = new List<LineData>();
        GenerateData();
    }

    public void SetLines(int stageNum)
    {
        foreach(LineData line in lineList)
        {
            if(stageNum < line.stageNum)
                break;
            
            if(stageNum == line.stageNum)
            {
                lineQueue.Enqueue(line);
            }
        }
    }
    
    public void ClearLineQueue()
    {
        lineQueue.Clear();
    }

    public string GetLine()
    {          
        if(lineIndex == lineQueue.Peek().lines.Length)
        {
            lineQueue.Dequeue();
            lineIndex = 0;
        }

        if(lineQueue.Count == 0)
        {
            GameManager.Instance.lineNumber++;
            return null;
        }
        
        return lineQueue.Peek().lines[lineIndex];
    }
}
