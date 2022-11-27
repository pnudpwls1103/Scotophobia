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
        render.flipX = (playerSkeleton.skeleton.ScaleX < 0) ? true : false; 
        transform.position = new Vector2(playerTrans.position.x - 2f, playerTrans.position.y + 4f);
    }

    void UpdateAuto()
    {

    }
}
