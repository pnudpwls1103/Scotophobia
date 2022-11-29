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
        questList.Add(0, new QuestData("½ÃÀÛ", new int[]{}));
        questList.Add(10, new QuestData("½ÃÀÛÆäÀÌÁö Å¬¸¯", new int[]{}));
        questList.Add(20, new QuestData("»÷µåÀ§Ä¡ ¸¸µé±â", new int[]{1000}));
        questList.Add(30, new QuestData("»÷µåÀ§Ä¡ °Ç³»ÁÖ±â", new int[]{2000}));
        questList.Add(40, new QuestData("½ºÅ×ÀÌÁö1 ÀÚ¹°¼è ¿­±â", new int[]{3000}));
        questList.Add(50, new QuestData("Ã¥ ¹è¿­", new int[]{4000}));
        questList.Add(60, new QuestData("°ø »Ì±â", new int[]{5000}));
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
        GameManager gameManager = GameManager.Instance;
        PuzzleTrigger puzzleTrigger;
        QuestTrigger questTrigger;
        HintTrigger hintTrigger;
        questList[questId].cleared = true;
        switch(questId)
        {
            case 0:
                gameManager.SetLineQueue();
                gameManager.Action(null);
                break;
            case 10:
                gameManager.FadeImage.PlayFadeIn();
                Time.timeScale = 1f;
                gameManager.lifeManager.SetUI(true);
                gameManager.clockImage.gameObject.SetActive(true);
                break;
            case 20:
                gameManager.SetLineQueue();
                gameManager.Action(null);
                questObject[1].SetActive(true);
                puzzleTrigger = questObject[0].GetComponent<PuzzleTrigger>();
                puzzleTrigger.Restore();
                puzzleTrigger.isActivate = false;
                Inventory.Instance.Insert("Sandwich");
                break;
            case 30:
                Debug.Log("»÷µåÀ§Ä¡ ÄÆ¾À");
                questObject[1].SetActive(false);
                questTrigger = questObject[1].GetComponent<QuestTrigger>();
                questTrigger.isActivate = false;
                gameManager.globalLight.SetIntensity(0.4f);
                gameManager.globalLight.SetColor(new Color32(178, 158, 255, 255));
                questObject[2].SetActive(true);
                questObject[3].GetComponent<HintTrigger>().isActivate = false;
                questObject[4].GetComponent<HintTrigger>().isActivate = false;
                questObject[5].GetComponent<HintTrigger>().isActivate = true;
                questObject[6].GetComponent<HintTrigger>().isActivate = true;
                questObject[7].GetComponent<PuzzleTrigger>().isActivate = true;
                questObject[7].GetComponent<PuzzleTrigger>().isPlayerActive = true;
                questObject[7].GetComponent<PuzzleTrigger>().isCameraActive = true;
                gameManager.lifeManager.SetTimer();
                break;
            case 40:
                gameManager.lifeManager.ResetTimer();
                gameManager.lifeManager.SetLife(5);
                questObject[2].SetActive(false);
                Debug.Log("¿ÊÀå ÄÆ¾À");
                puzzleTrigger = questObject[7].GetComponent<PuzzleTrigger>();
                puzzleTrigger.Restore();
                puzzleTrigger.isActivate = false;
                for(int i = 3; i <= 6; i++)
                    questObject[i].GetComponent<HintTrigger>().isActivate = false;
                gameManager.globalLight.SetIntensity(0.7f);
                gameManager.globalLight.SetColor(new Color32(255, 255, 255, 255));
                gameManager.LimitStage = 20000;
                gameManager.doorManager.SetActivate();
                break;
            case 50:
                gameManager.doorManager.SetActivate();
                puzzleTrigger = questObject[6].GetComponent<PuzzleTrigger>();
                puzzleTrigger.Restore();
                puzzleTrigger.isActivate = false;
                break;
            default:
                break;
        }
    }
}