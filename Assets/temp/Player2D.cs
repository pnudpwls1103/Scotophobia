using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2D : MonoBehaviour
{
    private float playerSpeed = 10.0f;
    public GameObject stair;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
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
            transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }
    }

    void OnTriggerStay2D(Collider2D other) {
       if(other.CompareTag("object")) 
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                
                if(hit.collider != null && hit.collider.transform == this.transform)
                {
                    SceneManager.LoadScene("mini-puzzle1");
                }
            }
        }
    }
}