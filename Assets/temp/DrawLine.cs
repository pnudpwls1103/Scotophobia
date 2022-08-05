using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private float lineWidth = 0.5f;
    private LineRenderer lr;
    private Vector3[] linePoints = new Vector3[2];

    public GameObject connectedProduct;
    private RaycastHit hit;

    private bool mouseButton = false;

    private void OnMouseDown()
    {
        mouseButton = true;
    }

    private void OnMouseUp()
    {
        mouseButton = false;
        lr.enabled = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject != this.gameObject)
            {
                connectedProduct = hit.collider.gameObject;

                Debug.Log(hit.collider.gameObject.name + " is connected");

                lr.enabled = true;

                /* 선택된 오브젝트에 라인 연결 */
                linePoints[1] = hit.collider.gameObject.transform.position;
                lr.SetPositions(linePoints);

                GameManager.Instance.SetClearPuzzle(1);

                return;
            }

            if (hit.collider.gameObject == this.gameObject)
            {
                if (connectedProduct == null) return;
            }
        }

        connectedProduct = null; /* 빈 공간 hit */
        Debug.Log("failed to connect");
    }

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        lr.material.color = Color.red;
        lr.widthMultiplier = lineWidth;
        linePoints[0] = transform.position; /* 첫번째 점의 위치는 gameobject */
        lr.positionCount = linePoints.Length;
    }

    void Update()
    {
        if (mouseButton)
        {
            lr.enabled = true;

            linePoints[1] = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

            lr.SetPositions(linePoints);
        }
    }
}
