using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool[] puzzleCheck = new bool[] {false, false,};
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
        if(SceneManager.GetActiveScene().name == "Temp 1")
        {
            if(puzzleCheck[0] && GameObject.Find("stairParent").transform.Find("stair").gameObject.activeSelf == true)
            {
                GameObject.Find("stair").gameObject.SetActive(false);
                GameObject.Find("stair2Parent").transform.Find("stair2").gameObject.SetActive(true);
            }

        }    
    }

    public void SetClearPuzzle(int index)
    {
        puzzleCheck[index] = true;
    }

    public bool GetClearPuzzle(int index)
    {
        return puzzleCheck[index];
    }
}
