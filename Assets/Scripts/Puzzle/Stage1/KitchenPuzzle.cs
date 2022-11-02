using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPuzzle : MonoBehaviour, IInteraction
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject gameObject)
    {
        GameManager gameManager = GameManager.Instance;
        gameManager.questManager.SetQuestClear(10);
        gameManager.questManager.CheckQuest(0);
        //gameManager.SetPlayerPosition(new Vector3(73, -100, 0));
    }
}
