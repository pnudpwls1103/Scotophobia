using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PicturePuzzle : MonoBehaviour
{
    int[] dx = new int[4] { 1, 0, -1, 0 };
    int[] dy = new int[4] { 0, 1, 0, -1 };
    const int MAP_SIZE = 4;
    [Serializable]
    struct Coordinate
    {
        public int row;
        public int col;
    }

    [Serializable]
    class Information
    {
        public Coordinate[] goalPosInf = new Coordinate[MAP_SIZE];
        public Sprite[] spriteInf = new Sprite[MAP_SIZE];
    }
    [Serializable]
    class Layout
    {
        [Range(0f, 2f)]
        public float size = 1f;
        public float distance = 30f;
    }

    [SerializeField]
    Information[] information = new Information[MAP_SIZE];
    [SerializeField]
    Layout layout = new Layout();
    GameObject[,] pieces = new GameObject[MAP_SIZE, MAP_SIZE];
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject go = new GameObject($"piece{MAP_SIZE * i + j}");
                go.transform.parent = transform;
                go.AddComponent<SpriteRenderer>();
                go.AddComponent<PicturePiece>();
                go.AddComponent<BoxCollider2D>();
                if (information[i].spriteInf[j] != null)
                    go.GetComponent<SpriteRenderer>().sprite = information[i].spriteInf[j];
                go.GetComponent<PicturePiece>().OnClick += OnPieceClicked;
                go.GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);
                go.transform.localScale = new Vector3(1, 1, 1) * layout.size;
                go.transform.localPosition = new Vector3(layout.distance * j, layout.distance * i * (-1), 0f);
                pieces[i, j] = go;
            }
        }
    }

    void CheckClear()
    {
        for (int i = 0; i < MAP_SIZE; i++)
            for (int j = 0; j < MAP_SIZE; j++)
            {
                Sprite sprite = pieces[i, j].GetComponent<SpriteRenderer>().sprite;
                if (sprite == null)
                    return;
                if (!IsEqual(information[i].goalPosInf[j].row * layout.distance * (-1), pieces[i, j].transform.localPosition.y)
                    || !IsEqual(information[i].goalPosInf[j].col * layout.distance, pieces[i, j].transform.localPosition.x))
                    return;
            }
        Debug.Log("Puzzle Clear");
    }
    bool IsEqual(float goal, float cur)
    {
        if (MathF.Abs(goal - cur) > 0.1f)
            return false;
        return true;
    }
    void OnPieceClicked(float row, float col)
    {
        int i = (int)((row / layout.distance) - 0.2f) * (-1);
        int j = (int)((col / layout.distance) + 0.2f);
        for (int k = 0; k < 4; k++)
        {
            int nx = i + dx[k];
            int ny = j + dy[k];
            if (nx >= 0 && nx < MAP_SIZE && ny >= 0 && ny < MAP_SIZE)
            {
                Sprite sprite = pieces[nx, ny].GetComponent<SpriteRenderer>().sprite;
                if (sprite == null)
                {
                    GameObject tmpGo = pieces[i, j];
                    Vector2 tmpPos = pieces[i, j].transform.position;
                    Coordinate tmpCo = information[i].goalPosInf[j];
                    pieces[i, j].transform.position = pieces[nx, ny].transform.position;
                    information[i].goalPosInf[j] = information[nx].goalPosInf[ny];
                    pieces[nx, ny].transform.position = tmpPos;
                    information[nx].goalPosInf[ny] = tmpCo;
                    pieces[i, j] = pieces[nx, ny];
                    pieces[nx, ny] = tmpGo;
                    return;
                }
            }
        }
    }
}