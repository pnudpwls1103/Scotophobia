using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Vector3 playerPosition;
    public bool[] stage1PuzzleCheck = {false, false};
    private static GameManager _instance;
    public static GameManager Instance
    {
        get 
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스 할당
            if(!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if(_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake() 
    {
        if(_instance == null)
        {
            _instance = this;
            if(SceneManager.GetActiveScene().name == "Stage1_Room1")
            {
                playerPosition = new Vector3(-7, -4, 0);
            }
        }
        // 인스턴스가 존재하는 경우 새로 생기는 인스턴스를 삭제
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        // 씬이 전환되더라도 선언되었던 인스턴스는 파괴되지 않음
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        SetObjectStage1();    
    }

    private void SetObjectStage1()
    {
        if(SceneManager.GetActiveScene().name == "Stage1_Room1")
        {
            if(stage1PuzzleCheck[(int)Define.Stage1Enum.Bookshelf] 
                && GameObject.Find("StairParent").transform.Find("Stair").gameObject.activeSelf == true)
            {
                GameObject.Find("Stair").gameObject.SetActive(false);
                GameObject.Find("UpStairParent").transform.Find("UpStair").gameObject.SetActive(true);
            }
        }

    }

    public void SetClearPuzzle(int index)
    {
        stage1PuzzleCheck[index] = true;
    }

    public bool GetClearPuzzle(int index)
    {
        return stage1PuzzleCheck[index];
    }
}
