using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TalkManager talkManager;

    // 대화창
    public GameObject talkPanel;
    public Text UITalkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id);

        //대화창 활성화 상태에 따라 대화창 활성화 변경
        talkPanel.SetActive(isAction); 
    }
    void Talk(int id)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        Debug.Log(talkData);
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        UITalkText.text = talkData;
        isAction = true;
        talkIndex++;
    }


}