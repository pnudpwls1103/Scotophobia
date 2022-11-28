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
    public bool canMove = true;
    public bool canClick = true;

    public float maxDistance = 9f;
    public GameObject scanObject;
    public GameObject scanClickObject;
    
    Rigidbody2D rigid;
    SkeletonAnimation skeletonAnimation;

    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        speed = bulb ? bulbOnSpeed : bulbOffSpeed;
        rigid = GetComponent<Rigidbody2D>();
        OnBulbOn += SpeedUp;
        OnBulbOff += SpeedDown;
        skeletonAnimation.skeleton.ScaleX = -Mathf.Abs(skeletonAnimation.skeleton.ScaleX);
    }

    void Update()
    {
        if(canMove)
            Move();
        else
            skeletonAnimation.AnimationState.SetAnimation(0, "animation", true);

        GetScanObjectMouse();

        if (scanClickObject)
            Interact();
        if (Input.GetKeyDown(KeyCode.I))
            UI_Root.TogglePopup(typeof(Define.UI_Popup), (int)Define.UI_Popup.Inventory);
        if (Input.GetKeyDown(KeyCode.O))
            ToggleBulb();
        if (Input.GetKeyDown(KeyCode.P))
            GetItem();
        if (Input.GetKeyDown(KeyCode.Space))
            GameManager.Instance.Action(scanObject);
            
    }

    void FixedUpdate()
    {
        ScanObject();
    }

    private void ScanObject()
    {
        Debug.DrawRay(new Vector3(this.transform.position.x, this.transform.position.y + 2, 0), new Vector3(direction * 2, 0, 0), Color.red);
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y + 2), new Vector2(direction, 0), 2, LayerMask.GetMask("Object"));
        if (hit.collider != null)
        {
            Debug.Log(hit.transform.gameObject.name);
            scanObject = hit.transform.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }

    private void GetScanObjectMouse()
    {
        if(canClick && Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray= new Ray2D(pos, Vector2.zero);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, LayerMask.GetMask("Object"));

            if(hit.collider != null)
            {
                float distance = Vector2.Distance(hit.transform.position, transform.position);
                if(distance <= maxDistance)
                    scanClickObject = hit.collider.gameObject;
                    
                return;
            } 
        }

        scanClickObject = null;
    }
    void Interact()
    {
        Collider2D col = scanClickObject.GetComponent<Collider2D>();
        if (col.GetComponent<IInteraction>() != null)
        {
            IInteraction inter = col.GetComponent<IInteraction>();
            inter.Interact(gameObject);
        }
    }
    void ToggleBulb()
    {
        if (bulb)
        {
           skeletonAnimation.Skeleton.SetSkin("skin2");
           OnBulbOff();
        }
            
        else
        {
           skeletonAnimation.Skeleton.SetSkin("skin1");
           OnBulbOn();
        }
            
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

        if(hAxis == 0)
           skeletonAnimation.AnimationState.SetAnimation(0, "animation", true);
        else
        {
           direction = hAxis;
           if(hAxis < 0)
               skeletonAnimation.skeleton.ScaleX = Mathf.Abs(skeletonAnimation.skeleton.ScaleX);
           else
               skeletonAnimation.skeleton.ScaleX = -Mathf.Abs(skeletonAnimation.skeleton.ScaleX);
        }
        rigid.position += Vector2.right * hAxis * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Monster"))
            Die();
    }

    public void Die()
    {
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