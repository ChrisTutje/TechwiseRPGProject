using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public static Grid Grid {get;private set;} //making a script just to pull the grid- so i dont have to do this same 4 lines of code in every script.


    public static List<Vector2Int> OccupiedCells {get; private set;}= new List<Vector2Int>();
    private void Awake()
    {
            Grid =  FindObjectOfType<Grid>();
            OccupiedCells.Clear();
    }
}
