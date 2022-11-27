using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public int questId;
    Dictionary<int, QuestData> questList;
    public GameObject[] questObject;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("»÷µåÀ§Ä¡ ¸¸µé±â", new int[]{1000}));
        questList.Add(20, new QuestData("»÷µåÀ§Ä¡ °Ç³»ÁÖ±â", new int[]{2000}));
        questList.Add(30, new QuestData("½ºÅ×ÀÌÁö1 ÀÚ¹°¼è ¿­±â", new int[]{3000}));
        questList.Add(40, new QuestData("Ã¥ ¹è¿­", new int[]{4000}));
        questList.Add(50, new QuestData("°ø »Ì±â", new int[]{5000}));
    }

    public void SetQuestClear(int questid)
    {
        questList[questId].cleared = true;
    }

    public int GetQuestTalkIndex()
    {
        return questId;
    }

    public string CheckQuest()
    {
        if(questList.ContainsKey(questId))
        {
            ControlObject();

            if(questList[questId].cleared)
                NextQuest();
            
            if(questList.ContainsKey(questId))
                return questList[questId].questName;
        }

        return null;
    }

    void NextQuest()
    {
        questId += 10;
    }

    void ControlObject()
    {
        PuzzleTrigger puzzleTrigger;
        QuestTrigger questTrigger;
        switch(questId)
        {
            case 10:
                questList[questId].cleared = true;
                GameManager.Instance.SetLineQueue();
                GameManager.Instance.Action(null);
                questObject[1].SetActive(true);
                puzzleTrigger = questObject[0].GetComponent<PuzzleTrigger>();
                puzzleTrigger.Restore();
                puzzleTrigger.isActivate = false;
                Inventory.Instance.Insert("Sandwich");
                break;
            case 20:
                questList[questId].cleared = true;
                Debug.Log("»÷µåÀ§Ä¡ ÄÆ¾À");
                questObject[1].SetActive(false);
                questTrigger = questObject[1].GetComponent<QuestTrigger>();
                questTrigger.isActivate = false;
                GameManager.Instance.globalLight.SetIntensity(0.4f);
                GameManager.Instance.globalLight.SetColor(new Color32(178, 158, 255, 255));
                questObject[2].SetActive(true);
                questObject[3].GetComponent<PuzzleTrigger>().isActivate = false;
                questObject[4].GetComponent<PuzzleTrigger>().isActivate = false;
                questObject[5].GetComponent<PuzzleTrigger>().isActivate = true;
                questObject[6].GetComponent<PuzzleTrigger>().isActivate = true;
                questObject[7].GetComponent<PuzzleTrigger>().isActivate = true;
                questObject[7].GetComponent<PuzzleTrigger>().isPlayerActive = true;
                questObject[7].GetComponent<PuzzleTrigger>().isCameraActive = true;
                break;
            case 30:
                questObject[2].SetActive(false);
                questList[questId].cleared = true;
                Debug.Log("¿ÊÀå ÄÆ¾À");
                puzzleTrigger = questObject[7].GetComponent<PuzzleTrigger>();
                puzzleTrigger.Restore();
                puzzleTrigger.isActivate = false;
                for(int i = 3; i <= 6; i++)
                    questObject[i].GetComponent<PuzzleTrigger>().isActivate = false;
                GameManager.Instance.globalLight.SetIntensity(0.7f);
                GameManager.Instance.globalLight.SetColor(new Color32(255, 255, 255, 255));
                GameManager.Instance.limitStage = 20000;
                GameManager.Instance.doorManager.SetActivate();
                break;
            case 40:
                questList[questId].cleared = true;
                GameManager.Instance.doorManager.SetActivate();
                puzzleTrigger = questObject[6].GetComponent<PuzzleTrigger>();
                puzzleTrigger.Restore();
                puzzleTrigger.isActivate = false;
                break;
            default:
                break;
        }
    }
}