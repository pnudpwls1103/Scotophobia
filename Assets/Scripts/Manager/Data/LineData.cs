using System.Collections;
using System.Collections.Generic;
public class LineData
{
    public int stageNum;
    public string name;
    public string[] lines;

    public LineData(int stageNum, string name, string[] lines)
    {
        this.stageNum = stageNum;
        this.name = name;
        this.lines = lines;
    }
}
