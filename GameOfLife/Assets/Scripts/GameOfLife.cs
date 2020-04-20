using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    public static GameOfLife instance;

    public bool isLoop;

    public int column;
    public int row;

    public GameObject CellPrefab;

    public Dictionary<Vector2Int, Cell> Cells;

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
        
    }

    void Init()
    {
        Cells.Clear();
        for (int i = 0; i < column; i++)
        {
            for (int j = 0; j < row; j++)
            {
                var go = GameObject.Instantiate(CellPrefab);
                go.transform.position = Vector3.zero;
                var cellScript = go.GetComponent<Cell>();
                Vector2Int pos = new Vector2Int(i, j);
                Cells[pos] = cellScript;
            }
        }
    }
    
}
