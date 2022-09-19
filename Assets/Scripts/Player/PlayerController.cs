using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour
{
    float speed;
    [SerializeField]
    float bulbOnSpeed;
    [SerializeField]
    float bulbOffSpeed;
    static bool bulb = false;
    public static event System.Action OnBulbOn = null;
    public static event System.Action OnBulbOff = null;
    
    Rigidbody2D rigid;

    void Start()
    {
        speed = bulb ? bulbOnSpeed : bulbOffSpeed;
        rigid = GetComponent<Rigidbody2D>();
        OnBulbOn += SpeedUp;
        OnBulbOff += SpeedDown;
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.I))
            UI_Root.TogglePopup(typeof(Define.UI_Popup), (int)Define.UI_Popup.Inventory);
        if (Input.GetKeyDown(KeyCode.O))
            ToggleBulb();
        if (Input.GetKeyDown(KeyCode.P))
            GetItem();
        if (Input.GetKeyDown(KeyCode.L))
            Interact();
    }

    void Interact()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1000f);
        foreach (Collider2D col in colliders)
            if (col.GetComponent<IInteraction>() != null)
            {
                IInteraction inter = col.GetComponent<IInteraction>();
                inter.Interact(gameObject);
                return;
            }
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
                Inventory.Instance.Insert(col.name);
                col.gameObject.SetActive(false);
                return;
            }
    }

    void Move()
    {
        float hAxis = Input.GetAxis("Horizontal");
        rigid.position += Vector2.right * hAxis * speed;
    }

    void SpeedUp()
    {
        speed = bulbOnSpeed;
    }
    void SpeedDown()
    {
        speed = bulbOffSpeed;
    }
}
