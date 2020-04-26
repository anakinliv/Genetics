 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
 using Random = UnityEngine.Random;

 public class Cell : MonoBehaviour
{
    public bool[] isAlive;
    private bool[] nextAlive;
    public Dictionary<Vector2Int, Cell> neighbours;

    public Vector2Int pos;

    public Image image;

    public GameOfLife gameOfLife;

    public void Generate()
    {
        for (int i = 0; i < 3; i++)
        {
            int otherAlive = 0;
            foreach (var other in neighbours)
            {
                if (other.Value.isAlive[i])
                {
                    otherAlive++;
                }
            }

            if (otherAlive == 3)
            {
                nextAlive[i] = true;
            }
            else if (otherAlive == 2)
            {
                nextAlive[i] = isAlive[i];
            }
            else
            {
                nextAlive[i] = false;
            }
        }
    }

    public void Doa()
    {
        float r = 0;
        float g = 0;
        float b = 0;
        for (int i = 0; i < 3; i++)
        {
            isAlive[i] = nextAlive[i];
            switch (i)
            {
                case 0:
                    r = isAlive[i] ? 1 : 0;
                    break;
                    case 1:
                        g = isAlive[i] ? 1 : 0;
                        break;
                        case 2:
                            b = isAlive[i] ? 1 : 0;
                            break;
            }
        }
        image.color = new Color(r, g, b, 1);
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

        image.rectTransform.sizeDelta = this.gameOfLife.glg.cellSize;

        nextAlive = new bool[3];
        nextAlive[0] = Random.value > 0.5f;
        nextAlive[1] = Random.value > 0.5f;
        nextAlive[2] = Random.value > 0.5f;
        isAlive = new bool[3];
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
