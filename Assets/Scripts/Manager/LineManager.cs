using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LineManager : MonoBehaviour
{    
    Queue<LineData> lineQueue;
    List<LineData> lineList;
    public int lineIndex = 0;
    void GenerateData()
    {
        lineList.Add(new LineData(1, "???", new string[]{"아이야, 나아가야 해"}));
        lineList.Add(new LineData(1, "아이", new string[]{"(아빠가 일어나기 전에 아침밥을 차려야 해.)", "(우리 아빠는 너무 상냥해)"}));

        lineList.Add(new LineData(2, "아빠", new string[]{"맛있어 보이는 샌드위치구나!"}));
        lineList.Add(new LineData(2, "아이", new string[]{"(아빠에게 샌드위치를 전해주자)"}));

        lineList.Add(new LineData(3, "???", new string[]{"아이야, 계속 나아가야 해. 너만이 해낼 수 있어."}));
        lineList.Add(new LineData(3, "아이", new string[]{"여길 벗어나고 싶어. 괴로워."}));
    
        lineList.Add(new LineData(4, "아빠", new string[]{"정리를 아주 잘 해놨더구나"}));
        lineList.Add(new LineData(4, "아빠", new string[]{"..."}));
        lineList.Add(new LineData(4, "아빠", new string[]{"하지만 늘 제대로 말을 듣는 법이 없구나. 니 엄마처럼"}));
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

    public Tuple<string, string> GetLine()
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
        
        LineData topData = lineQueue.Peek();
        return new Tuple<string, string>(topData.name, topData.lines[lineIndex]);
    }
}
