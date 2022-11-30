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
        questList.Add(0, new QuestData("시작 컷씬", new int[]{}));
        questList.Add(10, new QuestData("시작", new int[]{}));
        questList.Add(20, new QuestData("시작 대사", new int[]{}));
        questList.Add(30, new QuestData("샌드위치 만들기", new int[]{1000}));
        questList.Add(40, new QuestData("샌드위치 건내주기", new int[]{2000}));
        questList.Add(50, new QuestData("샌드위치 건내주기 컷씬", new int[]{2000}));
        questList.Add(60, new QuestData("스테이지1 자물쇠 열기", new int[]{3000}));
        questList.Add(70, new QuestData("스테이지1 클리어 대사", new int[]{}));
        questList.Add(80, new QuestData("아빠와 대화", new int[]{3000}));
        questList.Add(90, new QuestData("책 배열", new int[]{4000}));
        questList.Add(100, new QuestData("공 뽑기", new int[]{5000}));
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
                gameManager.cutSceneManager.VideoActive();
                gameManager.cutSceneManager.cutSceneIndex++;
                break;
            case 10:
                gameManager.fadeImage.gameObject.SetActive(true);
                gameManager.SetLineQueue();
                gameManager.Action(null);
                break;
            case 20:
                gameManager.fadeImage.PlayFadeIn();
                gameManager.lifeManager.SetUI(true);
                gameManager.clockImage.gameObject.SetActive(true);
                Time.timeScale = 1f;
                break;
            case 30:
                gameManager.SetLineQueue();
                gameManager.Action(null);
                questObject[1].SetActive(true);
                puzzleTrigger = questObject[0].GetComponent<PuzzleTrigger>();
                puzzleTrigger.Restore();
                puzzleTrigger.isActivate = false;
                Inventory.Instance.Insert("Sandwich");
                break;
            case 40:
                gameManager.cutSceneManager.VideoActive();
                gameManager.cutSceneManager.cutSceneIndex++;
                break;
            case 50:
                questObject[1].SetActive(false);
                questTrigger = questObject[1].GetComponent<QuestTrigger>();
                questTrigger.isActivate = false;
                gameManager.globalLight.SetIntensity(0.4f);
                gameManager.globalLight.SetColor(new Color32(178, 158, 255, 255));
                gameManager.player.GetComponent<PlayerController>().ToggleBulb();
                questObject[2].SetActive(true);
                questObject[3].GetComponent<HintTrigger>().isActivate = false;
                questObject[4].GetComponent<HintTrigger>().isActivate = false;
                questObject[5].GetComponent<HintTrigger>().isActivate = true;
                questObject[6].GetComponent<HintTrigger>().isActivate = true;
                questObject[7].GetComponent<PuzzleTrigger>().isActivate = true;
                questObject[7].GetComponent<PuzzleTrigger>().isPlayerActive = true;
                gameManager.lifeManager.SetTimer();
                break;
            case 60:
                gameManager.player.GetComponent<PlayerController>().ToggleBulb();
                gameManager.lifeManager.ResetTimer();
                gameManager.lifeManager.SetLife(5);
                questObject[2].SetActive(false);

                gameManager.cutSceneManager.VideoActive();
                gameManager.cutSceneManager.cutSceneIndex++;
                
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
            case 70:
                gameManager.SetLineQueue();
                gameManager.Action(null);
                break;
            case 80:
                puzzleTrigger = questObject[8].GetComponent<PuzzleTrigger>();
                puzzleTrigger.isActivate = true;
                break;
            case 90:
                puzzleTrigger = questObject[8].GetComponent<PuzzleTrigger>();
                puzzleTrigger.Restore();
                puzzleTrigger.isActivate = false;
                break;
            default:
                break;
        }
    }
}