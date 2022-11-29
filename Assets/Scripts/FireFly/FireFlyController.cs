using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class FireFlyController : MonoBehaviour
{
    public GameObject player;
    Transform playerTrans;
    SkeletonAnimation playerSkeleton;

    Define.FireFlyState fireFlyState = Define.FireFlyState.Chase;
    SpriteRenderer render;

    void Start()
    {
        render = gameObject.GetComponent<SpriteRenderer>();
        playerTrans = player.GetComponent<Transform>();
        playerSkeleton = player.GetComponent<SkeletonAnimation>();
    }

    void Update()
    {
        switch (fireFlyState)
        {
            case Define.FireFlyState.Chase: UpdateChase(); break;
            case Define.FireFlyState.Auto: UpdateAuto(); break;
        }
        

    }

    void UpdateChase()
    {
        float x = playerTrans.position.x;
        x = playerSkeleton.skeleton.ScaleX < 0 ? x + 2f : x - 2f;
        transform.position = new Vector2(x, playerTrans.position.y + 4f);
    }

    void UpdateAuto()
    {

    }
}
