using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform pos;
    public float checkRadius;
    public LayerMask isLayer;
    bool isGround;
    public float jumpPower = 3f;
    public float speed = 0.02f;
    static bool bulb = false;
    public static event System.Action OnBulbOn = null;
    public static event System.Action OnBulbOff = null;
    
    Rigidbody2D rigid;

    public GameObject driver;
    static public bool driverCheck = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        if(driverCheck)
        {
            driver.SetActive(false);
        }
        this.transform.position = GameManager.Instance.playerPosition;
    }

    void Update()
    {
        Move();
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, isLayer);
        if (isGround && Input.GetKeyDown(KeyCode.Space))
            Jump();
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (bulb)
                OnBulbOff();
            else
                OnBulbOn();
            bulb = !bulb;
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

    void OnTriggerStay2D(Collider2D other)
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if(hit.collider != null && hit.collider.transform == driver.transform)
            {
                driver.SetActive(false);
                driverCheck = true;
            }
        }    
    }

    void OnDestroy() {
        GameManager.Instance.playerPosition = this.transform.position;    
    }
}
