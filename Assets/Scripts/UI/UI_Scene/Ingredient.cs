using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ingredient : MonoBehaviour, IBeginDragHandler ,IDragHandler, IEndDragHandler
{
    IngredientMenu menu;
    CuttingBoard cuttingBoard;
    FryingPan fryingPan;
    [SerializeField]
    int order;
    [SerializeField]
    bool canPutOnCuttingBoard;
    [SerializeField]
    bool canPutOnFryingPan;
    Vector2 firstPos;
    public void OnBeginDrag(PointerEventData eventData)
    {
        firstPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.transform == null)
        {
            transform.position = firstPos;
            return;
        }
        if (hit.transform.name == "CuttingBoard" && canPutOnCuttingBoard && (cuttingBoard.order == order))
            cuttingBoard.Cook(gameObject);
        else if (hit.transform.name == "FryingPan" && canPutOnFryingPan && (fryingPan.order == order))
            fryingPan.Cook(gameObject);
        else
            transform.position = firstPos;
    }

    private void Start()
    {
        menu = GameObject.Find("IngredientMenu").GetComponent<IngredientMenu>();
        cuttingBoard = GameObject.Find("CuttingBoard").GetComponent<CuttingBoard>();
        fryingPan = GameObject.Find("FryingPan").GetComponent<FryingPan>();
    }
}
