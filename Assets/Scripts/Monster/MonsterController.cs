using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    float speed = 0.007f;

    Alarm toggleDir = new Alarm(minTime: 1.5f, maxTime: 8f);
    Alarm IdleMove = new Alarm(minTime: 3.5f, maxTime: 5f);

    Transform target;
    Vector2 dir = Vector2.right;
    Define.MonsterState monsterState = Define.MonsterState.Chase;
    Rigidbody2D rigid = null;
    Animator anim;
    void Start()
    {
        target = GameObject.Find("Player").transform;
        toggleDir.InitCurTime();
        IdleMove.InitCurTime();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
    }

    void Update()
    {
        if (CheckPlayerInSight() && monsterState != Define.MonsterState.Chase)
            monsterState = Define.MonsterState.Chase;
        else if (!CheckPlayerInSight() && monsterState == Define.MonsterState.Chase)
            monsterState = Define.MonsterState.Move;
        switch (monsterState)
        {
            case Define.MonsterState.Idle: 
                anim.SetBool("isWalk", false);
                UpdateIdle();
                break;
            case Define.MonsterState.Move: 
                anim.SetBool("isWalk", true);
                UpdateMove(); 
                break;
            case Define.MonsterState.Chase: 
                anim.SetBool("isWalk", true);
                UpdateChase(); 
                break;
            case Define.MonsterState.Attack: 
                UpdateAttack(); 
                break;
        }
    }

    bool CheckPlayerInSight()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.left);
        foreach (RaycastHit2D hit in hits)
            if (hit.transform.name == "Player")
                return true;
        hits = Physics2D.RaycastAll(transform.position, Vector2.right);
        foreach (RaycastHit2D hit in hits)
            if (hit.transform.name == "Player")
                return true;
        return false;
    }

    void UpdateIdle()
    {
        IdleMove.TimeGoes();

        if (IdleMove.IsTimeToEvent())
            ChangeBetweenIdleMove(Define.MonsterState.Move);
    }
    void UpdateMove() // 일정시간이 지나거나 벽에 부딪히면 방향 전환
    {
        IdleMove.TimeGoes();
        toggleDir.TimeGoes();

        rigid.position += dir * speed;
        if (toggleDir.IsTimeToEvent())
            ToggleDirection();
        if (IdleMove.IsTimeToEvent())
            ChangeBetweenIdleMove(Define.MonsterState.Idle, cutTime:2.5f);
    }
    void UpdateChase() // 전구 켜지면 플레이어 쫓아감
    {
        dir = (target.position - transform.position).normalized;
        FlipSprite();
        dir.y = 0;
        rigid.position += dir * speed;
    }
    void UpdateAttack() // 공격범위안에 플레이어있으면 공격
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            ToggleDirection();
    }
    void ToggleDirection()
    {
        toggleDir.InitCurTime();
        dir = -dir;
        FlipSprite();
    }
    void ChangeBetweenIdleMove(Define.MonsterState state, float cutTime = 0f)
    {
        IdleMove.InitCurTime(cutTime);
        monsterState = state;
    }

    void FlipSprite()
    {
        float x = Mathf.Abs(transform.localScale.x);
        x *= dir.x >= 0 ? -1 : 1;
        transform.localScale = new Vector2(x, transform.localScale.y);
    }
    //void OnBulbOn()
    //{
    //    monsterState = Define.MonsterState.Chase;
    //    speed = 0.12f;
    //}
    //void OnBulbOff()
    //{
    //    monsterState = Define.MonsterState.Chase;
    //    speed = 0.12f;
    //}
}