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
    Fade fade;
    void Start()
    {
        GameManager.Instance.ControlSceneObject(false, false);
        gameManager.lifeManager.SetUI(false);
        gameManager.clockImage.gameObject.SetActive(false);
        gameManager.globalLight.SetIntensity(1f);
    }

    public void Clear()
    {
        StartCoroutine(ClearLogic());
    }

    IEnumerator ClearLogic()
    {
        gameManager.UITalk.text = "»÷µåÀ§Ä¡°¡ ¿Ï¼ºµÆ´Ù";
        gameManager.linePanel.SetActive(true);
        yield return new WaitForSeconds(2); 
        cuttingBoard.DeleteAllIngredient();
        gameManager.globalLight.SetIntensity(0.7f);
        gameManager.linePanel.SetActive(false);
        gameManager.lifeManager.SetUI(true);
        gameManager.clockImage.gameObject.SetActive(true);
        gameManager.questManager.CheckQuest();
    }
}
