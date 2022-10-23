using System.Collections;
using System.Collections.Generic;

public class QuestData
{
    public string questName;
    public int[] objectId;
    
    
    public QuestData(string name, int[] objectids) {
        questName = name;
        objectId = objectids;
    }
}
