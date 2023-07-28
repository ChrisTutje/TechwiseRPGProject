using UnityEngine;
using System.Collections;
using System;

public class walk : MonoBehaviour {

    public float movespeed = 0.2f;
    public DateTime startTime = new DateTime();
   
    // Use this for initialization
    void Start () {
        startTime = DateTime.UtcNow;
    }

    // Update is called once per frame
    void Update () {

        if(DateTime.UtcNow - startTime < TimeSpan.FromSeconds(10)){
            transform.position = new Vector2(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
        }

    }
}