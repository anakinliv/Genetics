using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Line : MonoBehaviour
{
    public int length;
    public List<int> target;

    public List<Cell> cells;
    public List<int> cellDebugs;

    [ContextMenu("Test")]
    public void Test()
    {
        foreach (var VARIABLE in target)
        {
            
        }
    }

    public void SimpleBoxes()
    {
        
    }

    public bool check()
    {
        return true;
    }

    public void ShowAllPossibility()
    {
        var intervals = new int[target.Count];
        targetSum = 0;
        for (int i = 1; i < intervals.Length; i++)
        {
            intervals[i] = 1;
            targetSum += target[i];
        }
        cells = new List<Cell>();
        Try(intervals, cells, intervals.Length - 1);
    }

    private int targetSum = 0;
    public void Try(int[] intervals,List<Cell> cells,int index)
    {
        cells.Clear();
        int k = 0;
        int j = 0;
        while (j<target.Count)
        {
            for (int i = 0; i < intervals[j]; i++)
            {
                cells.Add(new Cell(){state = 0});
                k++;
            }
            for (int i = 0; i < target[j]; i++)
            {
                cells.Add(new Cell(){state = 1});
                k++;
            }
        }
        for (;k  < length; k++)
        {
            this.cells.Add(new Cell(){state = 0});
        }
        DebugCells(cells);
        intervals[index]++;
        int sum = 0;
        foreach (var VARIABLE in intervals)
        {
            sum += VARIABLE;
        }
        if (sum + targetSum > length)
        {
            
        }
    }

    public void DebugCells(List<Cell> debugCells)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var cell in debugCells)
        {
            switch (cell.state)
            {
                case 0:
                    sb.Append("-");
                    break;
                case 1:
                    sb.Append("o");
                    break;
                case 2:
                    sb.Append("x");
                    break;
            }
        }
    }
}
