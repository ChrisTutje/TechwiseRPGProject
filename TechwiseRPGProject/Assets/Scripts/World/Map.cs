using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{



    public static Dictionary<Vector2Int> OccupiedCells {get; private set;} = new Dictionary<Vector2Int>(); //list value to store which cells are occupied. This way we can determine where the character can not move I.E NPCS and

    public Grid Grid {get;private set;} //making a script just to pull the grid- so i dont have to do this same 4 lines of code in every script.
    private void Awake()
    {
            Grid =  FindObjectOfType<Grid>();
    }
}
