using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulbsPuzzle_4x4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(GameManager.Instance.GetClearPuzzle((int)Define.Stage1Enum.Bookshelf)
        //     && !GameManager.Instance.GetClearPuzzle((int)Define.Stage1Enum.BulbPuzzle)
        //     && Input.GetMouseButtonDown(0))
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        //     if(hit.collider != null && hit.collider.transform == this.transform)
        //     {
        //         SceneManager.LoadScene("Test_Stage1_bulb_puzzle_4x4");
        //     }
        // }    
    }
}
