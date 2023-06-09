using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    Transform playerTrans;
    [SerializeField]
    Vector2[] mapSizes = new Vector2[6];
    [SerializeField]
    Vector3 cameraPosition;

    public Vector2[] centers = new Vector2[6];
    

    [SerializeField]
    float cameraMoveSpeed;
    float height;
    float width;
    
    void Awake()
    {
        mapSizes[0] = new Vector2(16.19f, 0f);
        mapSizes[1] = new Vector2(18.19f, 0f);
        mapSizes[5] = new Vector2(27.195f, 5.4f);

        centers[0] = new Vector2(-20f, -24f);
        centers[1] = new Vector2(0f, -40f);
        centers[5] = new Vector2(0f, 0.4f);
    }

    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        LimitCameraArea();
    }

    void LimitCameraArea()
    {
        int stageNum = GameManager.Instance.CurrentStage / 10000 - 1;
        transform.position = Vector3.Lerp(transform.position, 
                                        playerTrans.position + cameraPosition,
                                        Time.deltaTime * cameraMoveSpeed);

        float lx = mapSizes[stageNum].x - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + centers[stageNum].x, lx + centers[stageNum].x);

        float ly = mapSizes[stageNum].y - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + centers[stageNum].y, ly + centers[stageNum].y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }

}
