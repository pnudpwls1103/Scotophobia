using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    float speed = 0.007f;

    Alarm toggleDir = new Alarm(minTime: 1.5f, maxTime: 8f);
    Alarm IdleMove = new Alarm(minTime: 3.5f, maxTime: 5f);

    [SerializeField]
    Transform target;
    Vector2 dir = Vector2.right;
    Define.MonsterState monsterState = Define.MonsterState.Chase;
    Rigidbody2D rigid = null;
    void Start()
    {
        target = GameObject.Find("Player").transform;
        toggleDir.InitCurTime();
        IdleMove.InitCurTime();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log($"current : {monsterState.ToString()}");
        switch (monsterState)
        {
            case Define.MonsterState.Idle: UpdateIdle(); break;
            case Define.MonsterState.Move: UpdateMove(); break;
            case Define.MonsterState.Chase: UpdateChase(); break;
            case Define.MonsterState.Attack: UpdateAttack(); break;
        }
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
    }
    void ChangeBetweenIdleMove(Define.MonsterState state, float cutTime = 0f)
    {
        IdleMove.InitCurTime(cutTime);
        monsterState = state;
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