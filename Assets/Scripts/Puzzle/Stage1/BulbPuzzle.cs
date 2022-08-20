using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulbPuzzle : UI_Base
{
    enum Images
    {
        bulb0, bulb1, bulb2, bulb3,
        bulb4, bulb5, bulb6, bulb7,
        bulb8, bulb9, bulb10, bulb11,
        bulb12, bulb13, bulb14, bulb15
    }
    int on = 0; // ���� �ִ� ������ ����
    bool[,] arr = new bool[4,4]; // ������ ����/����
    int[] dx = new int[5] { 1, -1, 0, 0, 0 };
    int[] dy = new int[5] { 0, 0, 1, -1, 0 };
    Color[] colors = new Color[2] { Color.black, Color.white };
    void Start()
    {
        Bind<Image>(typeof(Images));
        foreach (Component com in dic[typeof(Images)])
        {
            BulbInPuzzle bulbIn = com.GetComponent<BulbInPuzzle>();
            bulbIn.OnClickBulb += OnClickBulb;
        }
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
            {
                arr[i,j] = false;
                SetBulb(i, j);
            }
    }
    void OnClickBulb(int x, int y)
    {
        int nx, ny;
        for (int i = 0; i < 5; i++)
        {
            nx = x + dx[i];
            ny = y + dy[i];
            if (nx >= 0 && nx < 4 && ny >= 0 && ny < 4)
            {
                if (arr[nx, ny])
                    on--;
                else
                    on++;
                arr[nx, ny] = !arr[nx, ny];
                SetBulb(nx, ny);
            }
        }
        if (on == 16)
            Debug.Log("Clear!");
    }

    void SetBulb(int x, int y)
    {
        Image img = dic[typeof(Images)][x * 4 + y] as Image;
        int colorIdx = Convert.ToInt32(arr[x, y]);
        img.color = colors[colorIdx];
    }
}