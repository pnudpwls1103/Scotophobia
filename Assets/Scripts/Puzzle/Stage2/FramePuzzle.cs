using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramePuzzle : MonoBehaviour
{
    public GameObject target;
    public GameObject changeImage;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if(hit.collider != null && hit.collider.gameObject == target)
            {
                GameManager gameManager = GameManager.Instance;
                Debug.Log(hit.collider.name);
                gameManager.questManager.questOrderIndex++;
                gameManager.questManager.SetQuestClear(30);
                gameManager.questManager.CheckQuest(0);
            }
        }
    }
}
