using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    private float _speed = 10.0f;
    private 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
       
    }

    void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * _speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
    }

    void OnTriggerStay(Collider other) 
    {   
        if(other.CompareTag("object")) 
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    SceneManager.LoadScene("mini-puzzle1");
                    //GameObject book = GameObject.Find("book1");
                    //Vector3 pos;
                    //pos = book.gameObject.transform.position + Vector3.left * 5;
                    //transform.position = pos;
                }
            }
        }
    }
}