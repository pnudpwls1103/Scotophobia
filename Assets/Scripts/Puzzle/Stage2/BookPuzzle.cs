using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPuzzle : ObjectData
{
    [Serializable]
    class BookInfo
    {
        public Book book;
        public int order;
    }
    [SerializeField]
    BookInfo[] bookInfos;

    int lastClickedidx = -1;
    GameManager gameManager = null;
    void Start()
    {
        if(gameManager = GameManager.Instance)
        {
            GameManager.Instance.ControlSceneObject(false, false);
            gameManager.lifeManager.SetUI(false);
            gameManager.clockImage.gameObject.SetActive(false);
            gameManager.globalLight.SetIntensity(1f);
        }

        for (int i = 0; i < bookInfos.Length; i++)
        {
            bookInfos[i].book.onBookClicked -= OnBookClicked;
            bookInfos[i].book.onBookClicked += OnBookClicked;
            bookInfos[i].book.CurrentIdx = i;
        }
    }
    bool CheckClear()
    {
        foreach (BookInfo info in bookInfos)
            if (info.book.CurrentIdx != info.order)
                return false;
        return true;
    }

    void Clear()
    {
        GameManager.Instance.questManager.CheckQuest();
    }

    void OnBookClicked(int clickedIdx)
    {
        Debug.Log($"last : {lastClickedidx}, cur : {clickedIdx}");
        if (lastClickedidx == -1)
        {
            lastClickedidx = clickedIdx;
            return;
        }
        if (lastClickedidx == clickedIdx)
            return;
        
        BookInfo info = bookInfos[lastClickedidx];
        bookInfos[lastClickedidx].book.CurrentIdx = clickedIdx;
        bookInfos[lastClickedidx] = bookInfos[clickedIdx];
        bookInfos[clickedIdx].book.CurrentIdx = lastClickedidx;
        bookInfos[clickedIdx] = info;
        sort();
        lastClickedidx = -1;
        if (CheckClear())
            Clear();
    }

    void sort()
    {
        bookInfos[0].book.transform.parent.position = new Vector2(-7.4070f, -1.975f);
        for(int i = 1; i < bookInfos.Length; i++)
        {
            Vector2 pos = bookInfos[i-1].book.transform.parent.position;
            float sizeX = bookInfos[i-1].book.transform.GetComponent<BoxCollider2D>().size.x;
            pos = new Vector2(pos.x + sizeX, pos.y);
            bookInfos[i].book.transform.parent.position = pos;
        }
    }
}
