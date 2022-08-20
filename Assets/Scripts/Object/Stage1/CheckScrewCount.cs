using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckScrewCount : MonoBehaviour
{
    static public int finishScrewCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(finishScrewCount == 4)
        {
            GameManager.Instance.SetClearPuzzle((int)Define.stage1Enum.Bookshelf);
            SceneManager.LoadScene("Stage1_Room1");
        }
    }
}
