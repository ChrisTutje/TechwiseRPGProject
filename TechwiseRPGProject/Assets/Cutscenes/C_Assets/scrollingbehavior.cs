using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingbehavior : MonoBehaviour
{
    public float horizontal_speed = 0.2f;
    public float vertical_speed = 0.2f;

    private Renderer ren;
    void Start()
    {
        ren = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 offset = new Vector2(Time.time * horizontal_speed, Time.time * vertical_speed);
        ren.material.mainTextureOffset = offset;
    }
}
