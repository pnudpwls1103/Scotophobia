using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfPuzzle : MonoBehaviour, IInteraction
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
        gameManager.questManager.SetQuestClear(20);
        gameManager.questManager.CheckQuest(0);
    }
}
