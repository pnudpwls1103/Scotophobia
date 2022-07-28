using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform == transform)
                {
                    GameObject player = GameObject.Find("player");
                    GameObject stick = GameObject.Find("stick");
                    player.transform.position = stick.gameObject.transform.position + Vector3.left * 5;
                    if(stick.gameObject.activeSelf == true)
                        stick.gameObject.SetActive(false);

                    GameObject stair = GameObject.Find("stair");
                    if(stair.gameObject.activeSelf == true)
                        stair.gameObject.SetActive(false);
                    GameObject stair2 = GameObject.Find("stair2");
                    if(stair.gameObject.activeSelf == false)
                        stair2.gameObject.SetActive(true);
                }
            }
        }
    }
}
