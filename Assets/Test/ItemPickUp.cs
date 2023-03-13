using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    private InfoUIManager infoUIManager;

    [TextArea]
    public string infoText;
    Texture2D cursorOverImage;
    Texture2D cursorOriginImage;

    public Item item;

    void Start()
    {
        cursorOverImage = Resources.Load<Texture2D>("Sprites/UI/플레이어 커서");
        cursorOriginImage = Resources.Load<Texture2D>("Sprites/UI/마우스포인터");
    }

    private void OnMouseDown()
    {
        infoUIManager.SetInfoText(infoText);
        infoUIManager.EnableInfoUI();
    }

    private void OnMouseOver()
    {
        Cursor.SetCursor(cursorOverImage, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorOriginImage, Vector2.zero, CursorMode.Auto);
    }
}
