using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookPuzzle : ObjectData
{
    [SerializeField]
    CuttingBoard cuttingBoard;
    [SerializeField]
    FryingPan fryingPan;
    GameManager gameManager = GameManager.Instance;
    void Start()
    {
        gameManager.lifeManager.SetUI(false);
        gameManager.globalLight.SetIntensity(1f);
    }

    public void Clear()
    {
        StartCoroutine(ClearLogic());
    }

    IEnumerator ClearLogic()
    {
        gameManager.UIText.text = "»÷µåÀ§Ä¡°¡ ¿Ï¼ºµÆ´Ù";
        gameManager.talkPanel.SetActive(true);
        yield return new WaitForSeconds(2); 
        gameManager.globalLight.SetIntensity(0.7f);
        gameManager.questManager.CheckQuest();
        Debug.Log("Cook Puzzle Clear");
        gameManager.talkPanel.SetActive(false);
        gameManager.lifeManager.SetUI(true);
    }
}
