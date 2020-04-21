 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
 using Random = UnityEngine.Random;

 public class Cell : MonoBehaviour
{
    public bool isAlive;
    private bool nextAlive;
    public Dictionary<Vector2Int, Cell> neighbours;

    public Vector2Int pos;

    public Image image;

    public GameOfLife gameOfLife;

    public void Generate()
    {
        int otherAlive = 0;
        foreach (var other in neighbours)
        {
            if (other.Value.isAlive)
            {
                otherAlive++;
            }
        }

        if (otherAlive == 3)
        {
            nextAlive = true;
        }
        else if (otherAlive == 2)
        {
            nextAlive = isAlive;
        }
        else
        {
            nextAlive = false;
        }
    }

    public void Doa()
    {
        isAlive = nextAlive;
        if (isAlive)
        {
            image.color = Color.black;
        }
        else
        {
            image.color = Color.white;
        }
    }

    public void Init(GameOfLife gameOfLife,Vector2Int pos)
    {
        this.gameOfLife = gameOfLife;
        this.pos = pos;
        neighbours = new Dictionary<Vector2Int, Cell>();
        foreach (var other in gameOfLife.Cells)
        {
            if (isNeighbour(pos, other.Key))
            {
                neighbours[other.Key - pos] = other.Value;
                other.Value.neighbours[pos - other.Key] = this;
            }
        }

        nextAlive = Random.value > 0.5f;
        Doa();
    }
    
    

    int Distance(Vector2Int a, Vector2Int b)
    {
        return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
    }

    bool isNeighbour(Vector2Int a, Vector2Int b)
    {
        Vector2Int d = a - b;
        if (d.x == 0 && d.y == 0)
        {
            return false;
        }

        if (Math.Abs(d.x) > 1)
        {
            return false;
        }
        if (Math.Abs(d.y) > 1)
        {
            return false;
        }

        return true;
    }
}
