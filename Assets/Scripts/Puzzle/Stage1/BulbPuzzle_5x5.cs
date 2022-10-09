using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BulbPuzzle_5x5 : UI_Base
{
    const int MAXSIZE = 5;
    enum Images
    {
        bulb0, bulb1, bulb2, bulb3, bulb4,
        bulb5, bulb6, bulb7, bulb8, bulb9,
        bulb10, bulb11, bulb12, bulb13, bulb14,
        bulb15, bulb16, bulb17, bulb18, bulb19,
        bulb20, bulb21, bulb22, bulb23, bulb24,
    }
    int on = 0; // ���� �ִ� ������ ����
    bool[,] arr = new bool[MAXSIZE, MAXSIZE]; // ������ ����/����
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
        for (int i = 0; i < MAXSIZE; i++)
            for (int j = 0; j < MAXSIZE; j++)
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
            if (nx >= 0 && nx < MAXSIZE && ny >= 0 && ny < MAXSIZE)
            {
                if (arr[nx, ny])
                    on--;
                else
                    on++;
                arr[nx, ny] = !arr[nx, ny];
                SetBulb(nx, ny);
            }
        }
        if (on == MAXSIZE * MAXSIZE)
        {
            //GameManager.Instance.SetClearPuzzle((int)Define.Stage1Enum.BulbPuzzle);
            SceneManager.LoadScene("Stage1_Room1");
            Debug.Log("Clear!");
        }
    }

    void SetBulb(int x, int y)
    {
        Image img = dic[typeof(Images)][x * MAXSIZE + y] as Image;
        int colorIdx = Convert.ToInt32(arr[x, y]);
        img.color = colors[colorIdx];
    }
}