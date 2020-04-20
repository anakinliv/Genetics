 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

 public class Cell : MonoBehaviour
{
    public bool isAlive;
    public Dictionary<Vector2Int, Cell> neighbours;

    public Vector2Int pos;

    public Image image;

    public void Generate()
    {
        
    }
    
}
