using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Spine.Unity;
public class PlayerController : MonoBehaviour
{
    float direction;
    float speed;
    [SerializeField]
    float bulbOnSpeed;
    [SerializeField]
    float bulbOffSpeed;
    static bool bulb = false;
    public static event System.Action OnBulbOn = null;
    public static event System.Action OnBulbOff = null;

    public GameObject scanObject;
    
    Rigidbody2D rigid;
    private SkeletonAnimation skeletonAnimation;

    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
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
        if (Input.GetKeyDown(KeyCode.Space) && scanObject != null)
            GameManager.Instance.Action(scanObject);
            
    }

    void FixedUpdate()
    {
        Debug.DrawRay(new Vector3(this.transform.position.x, this.transform.position.y + 2, 0), new Vector3(direction * 2, 0, 0), Color.red);
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y + 2), new Vector2(direction, 0), 2, LayerMask.GetMask("Object"));
        if(hit.collider != null)
        {
            Debug.Log(hit.transform.gameObject.name);
            scanObject = hit.transform.gameObject;
        } else {
            scanObject = null;
        }
        
    }

    void Interact()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f);
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
        //if (bulb)
        //{
        //    skeletonAnimation.Skeleton.SetSkin("skin2");
        //    OnBulbOff();
        //}
            
        //else
        //{
        //    skeletonAnimation.Skeleton.SetSkin("skin1");
        //    OnBulbOn();
        //}
            
        bulb = !bulb;
    }
    void GetItem()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1000f);
        foreach (Collider2D col in colliders)
            if (col.GetComponent<Item>() != null)
            {
                Debug.Log($"Item {col.name} Get!");
                Inventory.Instance.Insert(col.name);
                return;
            }
    }

    void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");

        //if(hAxis == 0)
        //    skeletonAnimation.AnimationState.SetAnimation(0, "animation", true);
        //else
        //{
        //    direction = hAxis;
        //    if(hAxis < 0)
        //        skeletonAnimation.skeleton.ScaleX = Mathf.Abs(skeletonAnimation.skeleton.ScaleX);
        //    else
        //        skeletonAnimation.skeleton.ScaleX = -Mathf.Abs(skeletonAnimation.skeleton.ScaleX);
        //}
        rigid.position += Vector2.right * hAxis * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Monster"))
            Debug.Log("Player die!");
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
