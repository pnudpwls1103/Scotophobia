using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    Transform playerTrans;
    [SerializeField]
    Vector2[] mapSizes = new Vector2[2];
    [SerializeField]
    Vector3 cameraPosition;

    [SerializeField]
    Vector2 center;
    

    [SerializeField]
    float cameraMoveSpeed;
    float height;
    float width;
    
    void Awake()
    {
        mapSizes[0] = new Vector2(27.195f, 5.4f);
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
        int stageNum = GameManager.Instance.stageNumber/10000 - 1;
        transform.position = Vector3.Lerp(transform.position, 
                                        playerTrans.position + cameraPosition,
                                        Time.deltaTime * cameraMoveSpeed);

        float lx = mapSizes[stageNum].x - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        float ly = mapSizes[stageNum].y - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }

}
