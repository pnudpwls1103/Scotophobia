using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class PlayerTest : MonoBehaviour
{
    // health
    public float maxHealth = 100;
    public float currentHealth;
    public float stressSpeed;
    public HealthBar healthBar1;
    public HealthBar healthBar2;

    // bulb
    [SerializeField]
    float bulbOnSpeed;
    [SerializeField]
    float bulbOffSpeed;
    static bool bulb = false;
    public static event System.Action OnBulbOn = null;
    public static event System.Action OnBulbOff = null;

    // Move
    float speed;
    Rigidbody2D rigid;
    SkeletonAnimation skeletonAnimation;
    
    void Start()
    {
        // health
        currentHealth = 0;
        healthBar1.SetMaxHealth(maxHealth);
        healthBar2.SetMaxHealth(maxHealth);

        // bulb
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        speed = bulb ? bulbOnSpeed : bulbOffSpeed;
        rigid = GetComponent<Rigidbody2D>();
    }

    IEnumerator coroutine = null;
    void Update()
    {
        // Move
        float hAxis = Input.GetAxisRaw("Horizontal");
        if(hAxis == 0)
           skeletonAnimation.AnimationState.SetAnimation(0, "animation", true);
        else
        {
           if(hAxis < 0)
               skeletonAnimation.skeleton.ScaleX = Mathf.Abs(skeletonAnimation.skeleton.ScaleX);
           else
               skeletonAnimation.skeleton.ScaleX = -Mathf.Abs(skeletonAnimation.skeleton.ScaleX);
        }
        rigid.position += Vector2.right * hAxis * speed;

        // Bulb
        if (Input.GetKeyDown(KeyCode.O))
        {
            ToggleBulb();
            if(!bulb && coroutine == null)
            {
                coroutine = IncreaseStress(currentHealth);
                StartCoroutine(coroutine);
            }
            else if(coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }
    }

    // Health
    IEnumerator IncreaseStress(float health)
    {
        while(health < maxHealth)
        {
            health += Time.deltaTime * stressSpeed;
            currentHealth = health;
            healthBar1.SetHealth(currentHealth);
            healthBar2.SetHealth(currentHealth);
            yield return new WaitForFixedUpdate();
        }

        Debug.Log("스트레스 만땅");
    }

    // bulb
    public void ToggleBulb()
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
}