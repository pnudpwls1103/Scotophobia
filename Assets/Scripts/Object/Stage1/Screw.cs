using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
    private int clickCount = 0;
    private bool checkUpCount = false;
    private SpriteRenderer screwSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        screwSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(clickCount < 3 && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if(hit.collider != null && hit.collider.transform == this.transform)
            {
                clickCount++;
            }
        }
        else if(!checkUpCount && clickCount == 3)
        {
            checkUpCount = true;
            screwSpriteRenderer.color = new Color(0,1,1,1);
            CheckScrewCount.finishScrewCount++;
        }
    }
}
