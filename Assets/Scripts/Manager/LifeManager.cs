using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [SerializeField]
    Image[] UIhealth;
    [SerializeField]
    GameObject lifeObject;

    public event System.Action onTimer = null;
    public float LIMITTIME = 5f;
    public float time;    
    public int health = 5;

    void Update()
    {
        if(onTimer != null)
        {
            onTimer();
        }
            
    }

    void HealthDown()
    {
        UIhealth[health - 1].gameObject.SetActive(false);
        if(health > 1)
        {
            health--;
        }
        else
        {
            GameManager.Instance.player.GetComponent<PlayerController>().Die();
            ResetTimer();
        }
    }

    void DecreaseTime()
    {
        Animator anim = UIhealth[health - 1].GetComponent<Animator>();
        anim.SetBool("isBlink", true);

        time -= Time.deltaTime;
        if(time <= 0)
        {
            HealthDown();
            time = LIMITTIME;
        }
    }

    public void SetTimer()
    {
        onTimer += DecreaseTime;
    }

    public void ResetTimer()
    {
        onTimer -= DecreaseTime;
    }

    public void SetUI(bool state)
    {
        lifeObject.SetActive(state);
    }

    public void SetLife(int health)
    {
        this.health = health;
        for(int i = 0; i < health; i++)
            UIhealth[i].gameObject.SetActive(true);
    }
    
}
