using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 3f;
    public float speed = 0.02f;
    static bool bulb = false;
    public static event System.Action OnBulbOn = null;
    public static event System.Action OnBulbOff = null;
    
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.O))
            ToggleBulb();
        if (Input.GetKeyDown(KeyCode.P))
            GetItem();
    }
    void ToggleBulb()
    {
        if (bulb)
            OnBulbOff();
        else
            OnBulbOn();
        bulb = !bulb;
    }
    void GetItem()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1000f);
        foreach (Collider2D col in colliders)
            if (col.GetComponent<Item>() != null)
            {
                Debug.Log($"{col.name} È¹µæ");
                return;
            }
    }

    void Move()
    {
        float hAxis = Input.GetAxis("Horizontal");
        rigid.position += Vector2.right * hAxis * speed;
    }

    void Jump()
    {
        rigid.velocity = Vector2.up * jumpPower;
    }
}
