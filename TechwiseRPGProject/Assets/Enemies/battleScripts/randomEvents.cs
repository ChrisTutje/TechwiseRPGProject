using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomEvents : MonoBehaviour
{
     public static int d20() //rolling a D20
    {
        return Random.Range(1, 21); 
    }
}
