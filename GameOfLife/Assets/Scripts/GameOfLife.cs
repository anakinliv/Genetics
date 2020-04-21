using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOfLife : MonoBehaviour
{
    public static GameOfLife instance;

    public bool isLoop;

    public int column;
    public int row;

    public GameObject CellPrefab;

    public Dictionary<Vector2Int, Cell> Cells;
    public Transform root;
    private float updateTime;

    private void Awake()
    {
        Cells = new Dictionary<Vector2Int, Cell>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > updateTime)
        {
            foreach (var cell in Cells.Values)
            {
                cell.Generate();
            }
            foreach (var cell in Cells.Values)
            {
                cell.Doa();
            }

            updateTime += 0.3f;
        }
    }

    void Init()
    {
        Cells.Clear();
        GridLayoutGroup glg = root.GetComponent<GridLayoutGroup>();
        glg.constraintCount = column;
        glg.cellSize = new Vector2(500 / column, 500 / row);
        for (int i = 0; i < column; i++)
        {
            for (int j = 0; j < row; j++)
            {
                var go = GameObject.Instantiate(CellPrefab);
                go.transform.SetParent(root);
                var cellScript = go.GetComponent<Cell>();
                Vector2Int pos = new Vector2Int(i, j);
                Cells[pos] = cellScript;
                cellScript.Init(this,pos);
            }
        }
    }
    
}
