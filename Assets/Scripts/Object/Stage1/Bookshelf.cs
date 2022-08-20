using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bookshelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.driverCheck && !GameManager.Instance.GetClearPuzzle((int)Define.Stage1Enum.Bookshelf)
            && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if(hit.collider != null && hit.collider.transform == this.transform)
            {
                SceneManager.LoadScene("Stage1_Bookshelf");
            }
        }
    }
}
