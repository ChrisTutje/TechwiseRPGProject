using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridExtensions
    {
        //extension methods are to add onto the Grid class, to get rid of the annoyance of differences of Vector3 vs Vector2.
            public static Vector2Int GetCell2D(this Grid grid, GameObject gameObject)
            {
                Vector3 position = gameObject.transform.position;

                return(Vector2Int) grid.WorldToCell(position); //casting Vector2 onto the Vector3.
            }

            public static Vector2 GetCellCenter2D(this Grid grid, Vector2Int cell)
            {
                Vector3Int threeDimensionCell = new Vector3Int(cell.x, cell.y, 0); //making a vector3 out of the vector2 to comply with laws of universe.

                return (Vector2)grid.GetCellCenterWorld(threeDimensionCell); //more casting
            }
    }

