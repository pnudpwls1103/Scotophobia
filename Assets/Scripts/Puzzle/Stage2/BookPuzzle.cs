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
    void Start()
    {
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
        Debug.Log("BookPuzzle Clear");
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
        Vector2 pos = bookInfos[lastClickedidx].book.transform.position;
        BookInfo info = bookInfos[lastClickedidx];
        bookInfos[lastClickedidx].book.transform.position = bookInfos[clickedIdx].book.transform.position;
        bookInfos[lastClickedidx].book.CurrentIdx = clickedIdx;
        bookInfos[lastClickedidx] = bookInfos[clickedIdx];
        bookInfos[clickedIdx].book.transform.position = pos;
        bookInfos[clickedIdx].book.CurrentIdx = lastClickedidx;
        bookInfos[clickedIdx] = info;
        lastClickedidx = -1;
        if (CheckClear())
            Clear();
    }
}
