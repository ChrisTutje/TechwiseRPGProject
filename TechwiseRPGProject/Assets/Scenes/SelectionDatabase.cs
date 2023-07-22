using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SelectionDatabase : ScriptableObject
{
    public Selection[] selection;

    public int SelectionCount
    {
        get
        {
            return selection.Length;
        }
    }
    
    public Selection GetSelection(int index)
    { 
        return selection [index];
    }
}
