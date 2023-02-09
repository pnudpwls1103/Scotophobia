using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    [TextArea]
    public string infoText;
    Texture2D cursorOverImage;
    Texture2D cursorOriginImage;

    
    void Start()
    {
        cursorOverImage = Resources.Load<Texture2D>("Sprites/UI/플레이어 커서");
        cursorOriginImage = Resources.Load<Texture2D>("Sprites/UI/마우스포인터");
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Managers.Instance.infoUIManager.SetInfoText(infoText);
        Managers.Instance.infoUIManager.EnableUI();
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
